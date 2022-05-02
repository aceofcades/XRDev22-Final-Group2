using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// this way works but it's not a recommended way
/// link: https://www.youtube.com/watch?v=m5WsmlEOFiA
/// </summary>
public class FW_InputTest_2 : MonoBehaviour
{
    //private PlayerInput playerInput;

    //private FW_test inputActions;
    //// store our controls
    //private InputAction jumpAction;

    //private void Awake()
    //{
    //    inputActions = new FW_test();
    //    playerInput = GetComponent<PlayerInput>();
    //    jumpAction = playerInput.actions["Jump"];
    //    jumpAction.ReadValue<float>();
    //    jumpAction.started += Jump;        
    //}

    //public void Jump(InputAction.CallbackContext context)
    //{
    //    Debug.Log("jump~");
    //    context.ReadValue<float>();
    //    context.ReadValueAsButton();
    //}

    private FW_test inputActions;

    private void Awake()
    {
        inputActions = new FW_test();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        // add it so system start to listen and make the event ready
        inputActions.Default.Explosion.started += Explosion;
        //inputActions.Default.Explosion.performed += Explosion;
        //inputActions.Default.Explosion.canceled += Explosion;
    }

    
    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Default.Explosion.started -= Explosion;

    }


    public void Explosion(InputAction.CallbackContext context)
    {
        Debug.Log("explosion~");
        context.ReadValue<float>();
        context.ReadValueAsButton();
    }

    //Update is called once per frame
    void Update()
    {
        Vector2 move = inputActions.Default.Move.ReadValue<Vector2>();
            // compared to using update, it may be better to use the += subscript

        Debug.Log(move);
        if (inputActions.Default.Jump.triggered)
        {
            Debug.Log("jump");
        }
    }
}
