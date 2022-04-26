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
            SetMeshScale(other.gameObject, 2);
            theBall = other.gameObject;
            ballTriggerIsTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            SetMeshScale(other.gameObject, 0.5f);
            theBall = null;
            ballTriggerIsTriggered = false;
        }
    }

    /// <summary>
    /// search all objects (including all children)
    /// and just change the scale of obejcts with mesh renderer
    /// </summary>
    /// <param name="item"></param>
    /// <param name="scaleFactor"></param>
    public void SetMeshScale(GameObject item, float scaleFactor)
    {
        // check the item itself
        if (item.GetComponent<MeshRenderer>() != null)
        {
            item.transform.localScale *= scaleFactor;
        }

        foreach (Transform child in item.transform.GetComponentsInChildren<Transform>())
        {
            if (child.GetComponent<MeshRenderer>() != null)
            {
                child.transform.localScale *= scaleFactor;
            }
        }
    }
}
