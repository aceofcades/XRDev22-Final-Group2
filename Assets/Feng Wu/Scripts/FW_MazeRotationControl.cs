using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_MazeRotationControl : MonoBehaviour
{
    public float timeOfRotation = 5f;     // 5 second

    private GameObject maze;
    private bool rotationStepOneOn = false;      // rotationStart
    private bool rotationStepTwoOn = false;     // rotationProcess
    private Quaternion rotationAngle;    // get from ControlBalls
    private float timeCounting = 0;
    private Quaternion mazeRotationOrigin;      
    private Quaternion mazeRotationFinal;

    // Start is called before the first frame update
    void Start()
    {
        maze = FW_HandyMazeManagement.singleton.maze;
    }


    void Update()
    {
        if (FW_ControlBalls.singleton.MazeRotationShouldStart)
        {
            rotationStepOneOn = true;
            FW_ControlBalls.singleton.MazeRotationShouldStart = false;
        }
        // trigger to get existing rotation
        if (rotationStepOneOn)
        {
            Debug.Log("MazeRotationStepOne is running~");
            MazeRotationStepOne();
        }

        // Step Two, start the rotation process
        if (rotationStepTwoOn)
        {
            //Debug.Log("MazeRotationStepTwo is running~");
            float lerpTime = timeCounting / timeOfRotation;
            maze.transform.rotation = Quaternion.Lerp(mazeRotationOrigin, mazeRotationFinal, lerpTime);
            //Debug.Log(maze.transform.rotation.eulerAngles);
            if (timeCounting > timeOfRotation)
            {
                rotationStepTwoOn = false;      // all the maze rotation process done
                FW_ControlBalls.singleton.MazeRotationIsOngoing = false;
                FW_ControlBalls.singleton.ControlBallsRegeneration();   // reset all balls
            }
            timeCounting += Time.deltaTime;
        }
    }

    /// <summary>
    /// step one is for background setting, objects control, data collection
    /// </summary>
    public void MazeRotationStepOne()
    {
        // clean objects except handy maze
        FW_ControlBalls.singleton.ControlBallsCleaning();
        // reset timeCounting
        timeCounting = 0;
        // get all the data
        mazeRotationOrigin = maze.transform.rotation;
        //Debug.Log("mazeRotationOrigin =" + mazeRotationOrigin.eulerAngles);
        rotationAngle = FW_ControlBalls.singleton.RotationAngle;
        //Debug.Log("RotationAngle =" + FW_ControlBalls.singleton.RotationAngle.eulerAngles);
        //mazeRotationFinal = mazeRotationOrigin * rotationAngle;
        //Debug.Log("mazeRotationFinal_1 =" + mazeRotationFinal.eulerAngles);
        mazeRotationFinal = rotationAngle * mazeRotationOrigin;
        //Debug.Log("mazeRotationFinal_2 =" + mazeRotationFinal.eulerAngles);


        // formally turn on the rotation
        rotationStepTwoOn = true;
        // turn off the rotationTrigger
        rotationStepOneOn = false;
    }
}
