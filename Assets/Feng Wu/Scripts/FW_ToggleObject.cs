using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. toggle target object to make it active or not active
/// need to attach method to a button / trigger on controller
/// target object to be hidden (not active) on start
/// </summary>

public class FW_ToggleObject : MonoBehaviour
{
    public static FW_ToggleObject singleton;
    private GameObject handyMaze;

    private bool objectStatus = false;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        handyMaze = FW_HandyMazeManagement.singleton.handyMaze;
        handyMaze.SetActive(objectStatus);
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
        handyMaze.SetActive(objectStatus);
    }

    public void ToggleObjectOff()
    {
        objectStatus = false;
        handyMaze.SetActive(objectStatus);
    }
}
