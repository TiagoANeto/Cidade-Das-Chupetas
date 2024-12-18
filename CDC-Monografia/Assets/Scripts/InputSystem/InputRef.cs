using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[CreateAssetMenu(menuName = "InputRef")]
public class InputRef : ScriptableObject, InputMap.IPlayerActions, InputMap.IUIActions //Interfaces dos Action Maps
{
    private InputMap inputMap; //Referencia da classe C# inputsystem

    //Iniciando a classe das inputs e passando as intancias de cada Action Map
    public void OnEnable()
    {
        if(inputMap == null)
        {
            inputMap = new InputMap();

            inputMap.Player.SetCallbacks(this);
            inputMap.UI.SetCallbacks(this);

            SetGameplay();
        }
    }

    //Ativação do Action Map do player in Game 
    public void SetGameplay()
    {
        inputMap.Player.Enable();
        inputMap.UI.Disable();
    }

    //Ativação do Action Map de UIs, pauseGame e navegação de interfaces 
    public void SetUI()
    {
        inputMap.UI.Enable();
        inputMap.Player.Disable();
    }

    //Declaração dos Eventos que seram feitas as atribuições das inputs
    public event Action<Vector2> MoveEvent;
    public event Action JumpEvent;
    public event Action PauseEvent;

    public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    public void OnPause(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            PauseEvent.Invoke();
            SetUI();
        }
    }

} //Code and Comments by: Titi :3
