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

    public GameObject ball;
    
    private Transform controlBalls;
    private Transform controlBallsOrigin;

    // Create a dictionary for active balls (object, transform)
    private Dictionary<GameObject, Transform> ballsDict = new Dictionary<GameObject, Transform>();

    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        controlBalls = FW_HandyMazeManagement.singleton.controlBalls.transform;
    }

    /// <summary>
    /// mothod for HandyMazeManagement
    /// </summary>
    public void LeftHandSelectEnter()
    {
        ControlBallsRegeneration();
    }

    /// <summary>
    /// mothod for HandyMazeManagement
    /// </summary>
    public void LeftHandSelectExit()
    {
        ControlBallsCleaning();
    }

    /// <summary>
    /// manage the control balls, instantiate them when show up
    /// </summary>

    private GameObject[] balls = new GameObject[4];     // array length = 4 balls
    private float controlBallDistance = 0.15f;

    public void ControlBallsRegeneration()
    {
        // do all cleaning first
        ControlBallsCleaning();

        // turn on Trigger
        FW_BallTrigger.singleton.gameObject.SetActive(true);

        // create 4 control balls
        // move control balls to the right position - right, left, forward, backward
        balls[0] = Instantiate(ball, controlBalls);
        //Debug.Log("position_1.1" + balls[0].transform.position);
        balls[0].transform.position += new Vector3(controlBallDistance, 0, 0);
        //Debug.Log("position_1.2" + balls[0].transform.position);
        balls[1] = Instantiate(ball, controlBalls);
        balls[1].transform.position += new Vector3(-controlBallDistance, 0, 0);
        balls[2] = Instantiate(ball, controlBalls);
        balls[2].transform.position += new Vector3(0, 0, controlBallDistance);
        balls[3] = Instantiate(ball, controlBalls);
        balls[3].transform.position += new Vector3(0, 0, -controlBallDistance);

        // record center location for reference
        controlBallsOrigin = controlBalls;
        // record their position for reference
        foreach (Transform child in controlBalls)
        {
            // add child info into the dictionary, for reference
            ballsDict.Add(child.gameObject, child.transform);
        }
    }

    public void ControlBallsCleaning()
    {
        foreach (Transform child in controlBalls)
        {
            if (child != null)
            {
                //Debug.Log("child is " + child);
                GameObject.Destroy(child.gameObject);
            }
        }
        FW_BallTrigger.singleton.gameObject.SetActive(false);
        ballsDict.Clear();
    }

    //public void ControlBallsStateAdjustment()
    //{
    //    controlBallsOrigin = controlBalls;      // record center location for reference
    //    ballsDict.Clear();
    //    foreach (Transform child in controlBalls)
    //    {
    //        if (child.position.y == controlBalls.position.y)
    //        {
    //            child.gameObject.SetActive(true);

    //            // add child info into the dictionary, for reference
    //            ballsDict.Add(child.gameObject, child.transform);
    //        }
    //        else
    //        {
    //            child.gameObject.SetActive(false);
    //        }
    //    }
    //}


    public Quaternion rotationAngle;    // for maze rotation control
    public bool mazeRotationShouldStart = false;      // if true, maze start to rotate

    private GameObject theBall;     // the ball in ball trigger
    private Transform theBallOriginal;      // the ball's original transform
    //public float mazeRotationTime = 5f;     // time period of maze rotation

    /// <summary>
    /// used by HandyMazeManagement
    /// if Yes, rotate the maze, get rotation angle, output Yes, Clean all balls
    /// if No, reset the ball position
    /// </summary>
    public void MazeRotationByControllBallsChecking()
    {
        // when RightHand SelectionExit - if still in Trigger
        // then check ballDict, turn off ControlBalls, make Maze rotation
        if (FW_BallTrigger.singleton.ballTriggerIsTriggered)
        {
            theBall = FW_BallTrigger.singleton.theBall;
            ballsDict.TryGetValue(theBall, out Transform result);
            theBallOriginal = result;       // the the ball's original transform

            // calculate the rotation angle
            rotationAngle = Quaternion.FromToRotation((theBallOriginal.position - controlBallsOrigin.position).normalized, Vector3.up);
            Debug.Log("controlBallsOrigin.position =" + controlBallsOrigin.position);
            Debug.Log("theBallOriginal.position = " + theBallOriginal.position);
            Debug.Log("rotationAngle = " + rotationAngle.eulerAngles);
            // start maze rotation process in Update()
            mazeRotationShouldStart = true;
            Debug.Log("mazeRotationShouldStart = " + mazeRotationShouldStart);
        }
        else
        {
            mazeRotationShouldStart = false;
            ControlBallsRegeneration();
        }
    }
}
