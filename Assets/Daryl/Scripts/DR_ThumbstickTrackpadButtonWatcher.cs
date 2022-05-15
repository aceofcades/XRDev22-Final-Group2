using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class DR_ThumbstickTrackpadButtonEvent : UnityEvent<bool> { }
public class DR_ThumbstickTrackpadButtonWatcher: MonoBehaviour
{
    public DR_ThumbstickTrackpadButtonEvent thumbstickTrackpadButtonPress;

    private bool lastButtonState = false;
    private List<InputDevice> devicesWithThumbstickTrackpadButton;

    private void Awake()
    {
        if (thumbstickTrackpadButtonPress == null)
        {
            thumbstickTrackpadButtonPress = new DR_ThumbstickTrackpadButtonEvent();
        }

        devicesWithThumbstickTrackpadButton = new List<InputDevice>();
    }

    private void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach(InputDevice device in allDevices)
        {
            InputDevices_deviceConnected(device);
        }

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        devicesWithThumbstickTrackpadButton.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        bool discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out discardedValue))
        {
            // Add any devices that have a primary2DAxisClick interface (i.e. a Thumbstick or a Trackpad
            //  that the user can click)
            devicesWithThumbstickTrackpadButton.Add(device); 
        }    
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (devicesWithThumbstickTrackpadButton.Contains(device))
        {
            devicesWithThumbstickTrackpadButton.Remove(device);
        }
    }

    private void Update()
    {
        bool tempState = false;
        foreach(var device in devicesWithThumbstickTrackpadButton)
        {
            bool thumbstickTrackpadButtonState = false;
            tempState = device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out thumbstickTrackpadButtonState) // did get a value
                && thumbstickTrackpadButtonState // the value we got
                || tempState; // cumulative result from other controllers
        }

        if (tempState != lastButtonState) //Button state changed since last frame
        {
            thumbstickTrackpadButtonPress.Invoke(tempState);
            lastButtonState = tempState;
        }
    }
}

