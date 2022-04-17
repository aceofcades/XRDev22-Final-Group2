using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// match this object's rotation to the target object's rotation in real time
/// </summary>
public class FW_MatchRotation : MonoBehaviour
{
    public GameObject targetObject;     // object to be followed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = targetObject.transform.rotation;
    }
}
