using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    child.gameObject.AddComponent<BoxCollider>();
                }
            }
            Debug.Log("collider is added~");
        }
    }
}
