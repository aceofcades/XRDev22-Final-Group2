using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this code is used to set status for the telep area
/// </summary>
public class FW_MazeBoxTriggerAction : MonoBehaviour
{
    public bool test;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TelepArea")
        {
            other.gameObject.GetComponent<FW_TelepArea>().IsWithinMazeBox = true;
            test = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "TelepArea")
        {
            other.gameObject.GetComponent<FW_TelepArea>().IsWithinMazeBox = true;
            test = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TelepArea")
        {
            other.gameObject.GetComponent<FW_TelepArea>().IsWithinMazeBox = false;
            test = false;
        }
    }
}
