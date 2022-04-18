using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CM_HandAnimationManager : MonoBehaviour
{
    public Animator hand;

    public InputActionReference gripButton;

    private void Start()
    {
        gripButton.action.started += Action_started;
        gripButton.action.canceled += Action_canceled;

    }

    private void Action_canceled(InputAction.CallbackContext obj)
    {
        Released();
    }

    private void Action_started(InputAction.CallbackContext obj)
    {
        Gripped();
    }

    public void Gripped()
    {
        hand.SetBool("gripped", true);
    }

    public void Released()
    {
        hand.SetBool("gripped", false);
    }
}

