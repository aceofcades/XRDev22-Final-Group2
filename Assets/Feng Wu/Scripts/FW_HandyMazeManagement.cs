using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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

    private GameObject mazeInstance;

    // private GameObject mazeInHandyCube;
    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        DestroyAllChildren(handyCube_Scaled);
    }

    // use VRControllerInput component to attached left controller X to the below methods
    public void LeftHandSelectEnter()   // link to left controller event
    {
        FW_ToggleObject.singleton.ToggleObjectOn();
        DestroyAllChildren(handyCube_Scaled);
        MazeInstantiation();
        FW_ControlBalls.singleton.LeftHandSelectEnter();
        Debug.Log("leftHandSE is done~");
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

    private void DestroyAllChildren(GameObject parent)
    {
        foreach ( Transform child in parent.transform)
        {
            if (child != null)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    private void MazeInstantiation()
    {
        mazeInstance = Instantiate(maze, handyCube_Scaled.transform);
        mazeInstance.transform.localEulerAngles = Vector3.zero;
        Debug.Log("local scale =" +mazeInstance.transform.localScale);
        Debug.Log("global scale =" + mazeInstance.transform.lossyScale);
        // delete all collider in maze
        foreach (Transform child in mazeInstance.transform.GetComponentsInChildren<Transform>())
        {
            if (child.GetComponent<Collider>() != null)
            {
                Destroy(child.gameObject.GetComponent<Collider>());
                Destroy(child.gameObject.GetComponent<TeleportationArea>());
            }
        }
        Debug.Log("collider is deleted");
        //var allColliders = GetComponentsInChildren<BoxCollider>();
        //Debug.Log("allColliders length =" + allColliders.Length);
        //Debug.Log("allColliders =" + allColliders[15].name);
        //foreach (var childCollider in allColliders)
        //{
        //    childCollider.isTrigger = true;
        //    Destroy(childCollider);
        //}
    }
}
