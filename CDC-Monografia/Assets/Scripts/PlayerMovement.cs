using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Vector3 movement;
    public Vector2 movementInput;
    InputMap inputMap;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

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

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        transform.Translate(movement * speed * Time.deltaTime);
        
        animator.SetFloat("inputX", movement.x);
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, 0);
    }

     public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.1f)
        {
            isGrounded = true;
        }
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
