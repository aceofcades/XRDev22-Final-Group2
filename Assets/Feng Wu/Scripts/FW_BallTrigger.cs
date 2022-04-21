using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_BallTrigger : MonoBehaviour
{
    public static FW_BallTrigger singleton;

    public bool ballTriggerIsTriggered = false;
    public GameObject theBall;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        ballTriggerIsTriggered = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            other.gameObject.transform.localScale *= 2f;
            theBall = other.gameObject;
            ballTriggerIsTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            other.gameObject.transform.localScale /= 2f;
            theBall = null;
            ballTriggerIsTriggered = false;
        }
    }
}
