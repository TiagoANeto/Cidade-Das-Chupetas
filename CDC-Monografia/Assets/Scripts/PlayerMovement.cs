using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movement;
    public Vector2 movementInput;
    InputMap inputMap;
    private Rigidbody2D rb;
    private Animator animator;

    void Awake()
    {
        inputMap = new InputMap();
        inputMap.PlayerActions.Move.performed += Move;
        inputMap.PlayerActions.Move.canceled += Move;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        Gravity();
    }
    private void Movement()
    {
        transform.Translate(movement * speed * Time.deltaTime);
        
        if(movement.magnitude > 0.1f)
        {
            animator.SetFloat("inputX", movement.x);
        }
        else
        {
            animator.SetFloat("inputX", movement.x);
        }
    }

    private void Gravity()
    {
        
    }

    private void Flip()
    {

    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement = new Vector3(movementInput.x, 0, 0);
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
