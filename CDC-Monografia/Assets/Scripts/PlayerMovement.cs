using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 movement;
    public Vector2 movementInput;
    InputMap inputMap;
    private CharacterController cc;
    private Animator animator;
    
    void Awake()
    {
        inputMap = new InputMap();
        inputMap.PlayerActions.Move.performed += Move;
        inputMap.PlayerActions.Move.canceled += Move;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        cc.Move(movement * speed * Time.deltaTime);
        
        if(movement.magnitude > 0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
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
