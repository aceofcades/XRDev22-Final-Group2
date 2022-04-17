using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. toggle target object to make it active or not active
/// need to attach method to a button / trigger on controller
/// target object to be hidden (not active) on start
/// 2. Control balls management
/// </summary>
public class FW_ToggleObject : MonoBehaviour
{
    public GameObject targetObject;
    public Transform controlBalls;

    private bool objectStatus = false;


    private void Awake()
    {
        ControlBallsManagement();
    }

    private void Start()
    {
        targetObject.SetActive(objectStatus);
    }

    public void ToggleObjectButton()
    {
        if (objectStatus == false)
        {
            ToggleObjectOn();
        }
        else
        {
            ToggleObjectOff();
        }
    }

    public void ToggleObjectOn()
    {
        objectStatus = true;
        targetObject.SetActive(objectStatus);
        ControlBallsManagement();
    }

    public void ToggleObjectOff()
    {
        objectStatus = false;
        targetObject.SetActive(objectStatus);
    }

    /// <summary>
    /// manage the control balls, only make them activated when ball's Y == this object Y
    /// </summary>
    public void ControlBallsManagement()
    {
        foreach (Transform child in controlBalls)
        {
            if (child.position.y !=controlBalls.position.y)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
