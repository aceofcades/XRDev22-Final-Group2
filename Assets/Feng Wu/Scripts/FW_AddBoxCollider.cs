using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// add box collider for all the mesh in the object
/// </summary>
public class FW_AddBoxCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Transform[] allChildren = this.transform.GetComponentsInChildren<Transform>();
        //Debug.Log(allChildren.Length);
        if (this.transform.lossyScale == new Vector3(1,1,1))
            // add conditional, so handy maze will not add collider
        {
            foreach (Transform child in this.transform.GetComponentsInChildren<Transform>())
            {
                if (child.GetComponent<MeshRenderer>() != null)
                {
                    // add collider for keep the boundary
                    child.gameObject.AddComponent<BoxCollider>();

                    // add trigger to detect if there is things inside
                    BoxCollider trigger = child.gameObject.AddComponent<BoxCollider>();
                    trigger.isTrigger = true;
                    child.gameObject.AddComponent<FW_MazeBoxTriggerAction>();
                }
            }
            Debug.Log("collider is added~");
        }

        FW_TeleportationAreaManagement.singleton.AddTelepArea();
    }
}
