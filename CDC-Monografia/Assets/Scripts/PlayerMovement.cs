using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Declaration
    [SerializeField] private float speed;
    private Vector3 movement;
    public Vector2 movementInput;
    InputMap inputMap;
    public PlayerData data;
    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded;
    private bool isFalling;
    private bool isJumping;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheckPoint; 
    [SerializeField] private float _groundCheckSize = 0.2f; 
    [SerializeField] private LayerMask groundLayer;

    private float LastOnGroundTime; 

    #endregion

    void Awake()
    {
        inputMap = new InputMap();
        inputMap.PlayerActions.Move.performed += Move;
        inputMap.PlayerActions.Move.canceled += Move;
        inputMap.PlayerActions.Jump.performed += Jump;
        inputMap.PlayerActions.Jump.canceled += Jump;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        SetGravityScale(data.gravityScale);
    }

    void Update()
    {
        Movement();
        GroundCheck();

        if (isGrounded && rb.velocity.y <= 0)
        {
            isJumping = false;
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            rb.gravityScale = data.gravityScale * data.fallGravityMult; // Aumenta gravidade durante a queda
        }
        else
        {
            rb.gravityScale = data.gravityScale; 
        }

        LastOnGroundTime -= Time.deltaTime;
    }

    private void Movement()
    {
        transform.Translate(movement * speed * Time.deltaTime);
        animator.SetFloat("inputX", movement.x);
    }

    private void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, 0);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && (isGrounded || LastOnGroundTime > 0f) && !isJumping)
        {
            float force = data.jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reseta a velocidade Y antes do pulo
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isJumping = true;
            LastOnGroundTime = 0f; 
        }
    }

    private void GroundCheck()
    {
    Collider2D groundHit = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckSize, groundLayer);

        if (groundHit != null)
        {
            Debug.Log("Ground Detected: " + groundHit.gameObject.name);
            isGrounded = true;
        }
        else
        {
            Debug.Log("No Ground Detected!");
            isGrounded = false;
        }
    }

    public void SetGravityScale(float scale)
    {
        rb.gravityScale = scale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheckPoint.position, _groundCheckSize);
    }

    void OnEnable()
    {
        inputMap.PlayerActions.Enable();
    }

    void OnDisable()
    {
        inputMap.PlayerActions.Disable();
    }
}
