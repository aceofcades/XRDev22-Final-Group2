using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// use this one to manage the whole Handy Maze
/// </summary>
public class FW_HandyMazeManagement : MonoBehaviour
{
    public static FW_HandyMazeManagement singleton;

    [Header("link to internal objects")]
    public GameObject handyMaze;
    public GameObject controlBalls;
    public GameObject handyCube_Scaled;

    [Header("link to external objects")]
    public GameObject maze;
    // public GameObject leftHand;

    // private GameObject mazeInHandyCube;
    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        DestroyAllChildren(handyCube_Scaled);
    }

    public void LeftHandSelectEnter()   // link to left controller event
    {
        FW_ToggleObject.singleton.ToggleObjectOn();
        Instantiate(maze, handyCube_Scaled.transform);
        FW_ControlBalls.singleton.LeftHandSelectEnter();
    }

    public void LeftHandSelectExit()    // link to left controller event
    {
        DestroyAllChildren(handyCube_Scaled);
        FW_ToggleObject.singleton.ToggleObjectOff();
        FW_ControlBalls.singleton.LeftHandSelectExit();
    }

    public void BallSelectionExit()     // link to control ball prefab's interactable event
    {
        // check if the maze should start rotation
        Debug.Log("BallSelectionExit is running~");
        FW_ControlBalls.singleton.MazeRotationByControllBallsChecking();
    }

    public void DestroyAllChildren(GameObject parent)
    {
        foreach ( Transform child in parent.transform)
        {
            if (child != null)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
