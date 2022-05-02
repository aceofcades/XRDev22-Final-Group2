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

    public GameObject ball;     // link with ball prefab
    public GameObject ballTrigger;      // link with ballTrigger prefab
    
    private Transform controlBalls;
    private Vector3 controlBallsOrigin;

    // Create a dictionary for active balls (object, transform)
    private Dictionary<GameObject, Vector3> ballsDict = new Dictionary<GameObject, Vector3>();

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
        if (MazeRotationIsOngoing == false)
        {
            ControlBallsRegeneration();
        }

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

        // turn on Trigger and reset position
        FW_BallTrigger.singleton.gameObject.SetActive(true);
        FW_BallTrigger.singleton.gameObject.transform.position = controlBalls.position+ new Vector3(0, controlBallDistance, 0);

        // create 4 control balls
        // move control balls to the right position - right, left, forward, backward
        balls[0] = Instantiate(ball, controlBalls);
        //Debug.Log("position_1.1" + balls[0].transform.position);
        //Debug.Log("rotation_1.1" + balls[0].transform.rotation.eulerAngles);
        balls[0].transform.position += new Vector3(controlBallDistance, 0, 0);
        //Debug.Log("position_1.2" + balls[0].transform.position);
        balls[1] = Instantiate(ball, controlBalls);
        balls[1].transform.position += new Vector3(-controlBallDistance, 0, 0);
        balls[2] = Instantiate(ball, controlBalls);
        balls[2].transform.position += new Vector3(0, 0, controlBallDistance);
        balls[3] = Instantiate(ball, controlBalls);
        balls[3].transform.position += new Vector3(0, 0, -controlBallDistance);

        // record center position for reference
        controlBallsOrigin = controlBalls.position;
        // record their position for reference
        foreach (Transform child in controlBalls)
        {
            // add child info into the dictionary, for reference
            ballsDict.Add(child.gameObject, child.transform.position);
        }
    }


    public void ControlBallsCleaning()
    {
        foreach (GameObject item in balls)
        {
            if (item != null)
            {
                GameObject.Destroy(item.gameObject);
            }
        }
        FW_BallTrigger.singleton.gameObject.SetActive(false);
        ballsDict.Clear();
    }


    public Quaternion RotationAngle { get; set; }    // for maze rotation control
    public bool MazeRotationShouldStart { get; set; } = false;     // if true, maze start to rotate
    public bool MazeRotationIsOngoing { get; set; } = false;    // if true, stop generation balls

    private GameObject theBall;     // the ball in ball trigger
    private Vector3 theBallOriginal;      // the ball's original position
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
            FW_BallTrigger.singleton.ballTriggerIsTriggered = false;    // set it back to false
            theBall = FW_BallTrigger.singleton.theBall;
            ballsDict.TryGetValue(theBall, out Vector3 result);
            theBallOriginal = result;       // the the ball's original transform

            // calculate the rotation angle
            RotationAngle = Quaternion.FromToRotation((theBallOriginal - controlBallsOrigin).normalized, Vector3.up);
            //Debug.Log("controlBallsOrigin.position =" + controlBallsOrigin);
            //Debug.Log("theBallOriginal.position = " + theBallOriginal);
            //Debug.Log("rotationAngle = " + RotationAngle.eulerAngles);

            // start maze rotation process in Update()
            MazeRotationShouldStart = true;
            //Debug.Log("mazeRotationShouldStart = " + mazeRotationShouldStart);

            // switch status, will be set back to false by maze rotation control
            MazeRotationIsOngoing = true;
        }
        else
        {
            MazeRotationShouldStart = false;
            ControlBallsRegeneration();
        }
    }
}
