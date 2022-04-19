using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// match this object's rotation to the target object's rotation in real time
/// </summary>
public class FW_MatchRotation : MonoBehaviour
{
    private GameObject targetObject;     // object to be followed, link to maze

    // Start is called before the first frame update
    void Start()
    {
        targetObject = FW_HandyMazeManagement.singleton.maze;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = targetObject.transform.rotation;
    }
}
