using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// use this one to manage the whole Handy Maze
/// </summary>
public class FW_HandyMazeManagement : MonoBehaviour
{
    public static FW_HandyMazeManagement singleton;

    public GameObject maze;
    public GameObject leftHand;
    public GameObject handyMaze;
    public GameObject controlBalls;


    private void Awake()
    {
        singleton = this;
    }

    public void LeftHandSelectEnter()   // link to left controller event
    {
        FW_ToggleObject.singleton.ToggleObjectOn();
        FW_ControlBalls.singleton.LeftHandSelectEnter();
    }

    public void LeftHandSelectExit()    // link to left controller event
    {
        FW_ToggleObject.singleton.ToggleObjectOff();
        FW_ControlBalls.singleton.LeftHandSelectExit();
    }

    public void BallSelectionExit()     // link to control ball prefab's interactable event
    {
        // check if the maze should start rotation
        Debug.Log("BallSelectionExit is running~");
        FW_ControlBalls.singleton.MazeRotationByControllBallsChecking();
    }
}
