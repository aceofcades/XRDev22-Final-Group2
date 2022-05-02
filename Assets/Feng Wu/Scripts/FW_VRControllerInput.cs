using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

/// <summary>
/// this class is for listening VR controller Input: 
/// Left - X, Y; & Right - A, B
/// for testing, Left X is binding to Space as well
/// How to add a new one:
/// Step 1: add a new UnityEvent
/// Step 2.1: check InputAction file, add input action if needed
/// Step 2.2: add new subscriptions in both OnEnable and OnDisable
/// Step 3: add new method with the Invoke of the UnityEvent
/// </summary>
public class FW_VRControllerInput : MonoBehaviour
{
    private FW_VRControllerInputAction inputAction;

    [Header("Left Controller")]
    public UnityEvent Left_X_Started;
    public UnityEvent Left_X_Canceled;
    public UnityEvent Left_Y_Started;
    public UnityEvent Left_Y_Canceled;

    private void Awake()
    {
        inputAction = new FW_VRControllerInputAction();
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.VRController.LeftController_X.started += LeftControllerXStarted;
        inputAction.VRController.LeftController_X.canceled += LeftControllerXCanceled;
        inputAction.VRController.LeftController_Y.started += LeftControllerYStarted;
        inputAction.VRController.LeftController_Y.canceled += LeftControllerYCanceled;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.VRController.LeftController_X.started -= LeftControllerXStarted;
        inputAction.VRController.LeftController_X.canceled -= LeftControllerXCanceled;
        inputAction.VRController.LeftController_Y.started -= LeftControllerYStarted;
        inputAction.VRController.LeftController_Y.canceled -= LeftControllerYCanceled;
    }

    public void LeftControllerXStarted(InputAction.CallbackContext context)
    {
        //Debug.Log("LeftX is started~");
        Left_X_Started.Invoke();
    }

    public void LeftControllerXCanceled(InputAction.CallbackContext context)
    {
        //Debug.Log("LeftX is canceled~");
        Left_X_Canceled.Invoke();
    }

    public void LeftControllerYStarted(InputAction.CallbackContext context)
    {
        //Debug.Log("LeftX is started~");
        Left_Y_Started.Invoke();
    }

    public void LeftControllerYCanceled(InputAction.CallbackContext context)
    {
        //Debug.Log("LeftX is canceled~");
        Left_Y_Canceled.Invoke();
    }
}
