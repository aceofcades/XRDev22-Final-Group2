using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class CM_TeleportationController : MonoBehaviour
{
    static private bool _teleportIsActive = false;


    public enum ControllerType
    {
        RightHand,
        LeftHand
    }

    public ControllerType targetController;

    public InputActionAsset inputAction;

    public XRRayInteractor rayInteractor;

    public TeleportationProvider teleportationProvider;

    private InputAction _thumbstickInputAction;

    private InputAction _teleportActivate;

    private InputAction _teleportCancel;

    private void Start()
    {
        rayInteractor.enabled = false;

        Debug.Log("XRI " + targetController.ToString());
        _teleportActivate = inputAction.FindActionMap("XRI " + targetController.ToString()).FindAction("Teleport Mode Activate");
        _teleportActivate.Enable();
        _teleportActivate.performed += OnTeleportActivate;

        _teleportCancel = inputAction.FindActionMap("XRI " + targetController.ToString()).FindAction("Teleport Mode Cancel");
        _teleportCancel.Enable();
        _teleportCancel.performed += OnTeleportCancel;
    }


    private void Update()
    {
        if (!_teleportIsActive)
        {
            return;
        }
        if (!rayInteractor.enabled)
        {
            return;
        }
        if (_thumbstickInputAction.triggered)
        {
            return;
        }
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit))
        {
            Debug.Log(raycastHit);
            rayInteractor.enabled = false;
            _teleportIsActive = false;
            return;
        }

        Debug.Log(raycastHit);
        TeleportRequest teleportRequest = new TeleportRequest()
        {
            destinationPosition = raycastHit.point,
        };

        teleportationProvider.QueueTeleportRequest(teleportRequest);

        rayInteractor.enabled = false;
        _teleportIsActive = false;
    }


    private void OnTeleportActivate(InputAction.CallbackContext context)
    {
        if (!_teleportIsActive)
        {
            rayInteractor.enabled = true;
            _teleportIsActive = true;
        }
    }

    private void OnTeleportCancel(InputAction.CallbackContext contect)
    {
        if (_teleportIsActive && rayInteractor.enabled == true)
        {
            rayInteractor.enabled = false;
            _teleportIsActive = false;
        }
    }
}
