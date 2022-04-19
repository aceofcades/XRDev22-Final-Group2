using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2. Control balls state management
/// 3. Balls rotation by hand --> maze rotation
/// </summary>

public class FW_ControlBalls : MonoBehaviour
{
    public static FW_ControlBalls singleton;
    
    private Transform controlBalls;
    private Transform maze;
    private Transform controlBallsOrigin;
    private GameObject theBall;     // the ball in ball trigger

    // Create a dictionary for active balls (object, transform)
    private Dictionary<GameObject, Transform> ballsDict = new Dictionary<GameObject, Transform>();

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        maze = FW_HandyMazeManagement.singleton.maze.transform;
        controlBalls = FW_HandyMazeManagement.singleton.controlBalls.transform;
        ControlBallsStateAdjustment();
    }

    public void LeftHandSelectEnter()
    {
        ControlBallsStateAdjustment();
    }

    public void LeftHandSelectExit()
    {
        ballsDict.Clear();  // clean the dict. when exit
    }

    /// <summary>
    /// manage the control balls, only make them activated when ball's Y == this object Y
    /// </summary>
    public void ControlBallsStateAdjustment()
    {
        controlBallsOrigin = controlBalls;      // record center location for reference
        ballsDict.Clear();
        foreach (Transform child in controlBalls)
        {
            if (child.position.y == controlBalls.position.y)
            {
                child.gameObject.SetActive(true);

                // add child info into the dictionary, for reference
                ballsDict.Add(child.gameObject, child.transform);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private Transform theBallOriginal;      // the ball's original transform
    private bool mazeRotation = false;      // if true, maze start to rotate 90 degree
    public float mazeRotationTime = 3f;     // time period of maze rotation

    public void MazeRotationByControllBalls()
    {
        // when TriggerEnter - ball change scale *2 (maybe play audioClip) - done

        // when TriggerEist - ball scale change back /2 - done

        // when RightHand SelectionExit - if still in Trigger
        // then check ballDict, turn off ControlBalls, make Maze rotation
        if (FW_BallTrigger.singleton.ballTriggerIsTriggered)
        {
            theBall = FW_BallTrigger.singleton.theBall;
            ballsDict.TryGetValue(theBall, out Transform result);
            theBallOriginal = result;       // the the ball's original transform

            // calculate the rotation angle
            Quaternion.FromToRotation(theBallOriginal.position - controlBallsOrigin.position, Vector3.up);
            // start maze rotation process in Update()
            mazeRotation = true;
        }


        // run ControlBallsStateAdjustment() again
    }

    private void Update()
    {
        // if maze rotation is on
        if (mazeRotation == true)
        {
            float timeCounting = 0f;
            while (timeCounting <mazeRotationTime)
            {

            }

        }
        
    }

    // Method: if bool = true, Rotation with x (Qua or Euler) in y time (second)
    public void MazeRotation()
    {

    }
}
