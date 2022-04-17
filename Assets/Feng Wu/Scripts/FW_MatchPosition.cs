using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// match this object's position to target object's position
/// </summary>
public class FW_MatchPosition : MonoBehaviour
{
    public GameObject targetObject;     // link to left hand

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = targetObject.transform.position;
    }
}
