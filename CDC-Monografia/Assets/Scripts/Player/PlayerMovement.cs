using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Declaration
    [SerializeField] private float speed;
    public InputRef inputRef;
    private Vector3 movement;
    public Vector2 movementDirection;
    public PlayerData data;
    public Rigidbody2D rb;
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
        inputRef.MoveEvent += Move;
        inputRef.JumpEvent += Jump;

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

         //Verifica estado de aterrissagem do boneco
        if(isGrounded && rb.velocity.y <= 0)
        {
            isJumping = false; 
            isFalling = false; 
            animator.SetBool("isJumpingAnim", false);
        }
        else if(!isGrounded && rb.velocity.y < 0)
        {
            isFalling = true;
        }

        if(!isGrounded && rb.velocity.y > 0)
        {
        animator.SetBool("isJumpingAnim", true);
        }   

        //Ajustar gravidade para queda
        if(!isGrounded && rb.velocity.y < 0)
        {
            rb.gravityScale = data.gravityScale * data.fallGravityMult; 
        }
        else
        {
            rb.gravityScale = data.gravityScale;
        }

        LastOnGroundTime -= Time.deltaTime;
        animator.SetFloat("inputY", rb.velocity.y);
    }

    private void Movement()
    {
        if(movementDirection.magnitude > 0.1f)
        {
            transform.Translate(movement * speed * Time.deltaTime);
            animator.SetFloat("inputX", movement.x);
        }
        else
        {
            animator.SetFloat("inputX", 0);
        }
    }

    private void Move(Vector2 dir)
    {
        movementDirection = dir;
        movement = new Vector3(movementDirection.x, 0, 0);
    }

    private void Jump()
    {
        if ((isGrounded || LastOnGroundTime > 0f) && !isJumping)
        {
            float force = data.jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, 0); 
            rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isJumping = true;
            LastOnGroundTime = 0f;
            animator.SetBool("isJumpingAnim", isJumping);
        }
        else
        {   
            animator.SetBool("isJumpingAnim", !isJumping);
        }
    }

    private void GroundCheck()
    {
        Collider2D groundHit = Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckSize, groundLayer);

        isGrounded = groundHit != null;

        if (isGrounded)
        {
            LastOnGroundTime = 0.2f; 
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

    private void OnDisable(){ //desinscricao dos eventos necessarios para ser recarregado na cena - Ana :P
        inputRef.JumpEvent -= Jump;
    }
}
