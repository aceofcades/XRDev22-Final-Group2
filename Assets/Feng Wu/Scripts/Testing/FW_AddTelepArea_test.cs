using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FW_AddTelepArea_test : MonoBehaviour
{
    public GameObject area;
    //private TeleportationArea telepArea;
    //private BoxCollider telepCollider;
    //private BoxCollider objectCollider;
    //private List<Collider> colliderList;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(area, transform);
        //telepCollider = this.gameObject.GetComponent<BoxCollider>();
        //telepCollider.center = new Vector3(0, 0.506f, 0);
        //telepCollider.size = new Vector3(1, 0.01f, 1);

        //telepArea = this.gameObject.AddComponent<TeleportationArea>();

        ////colliderList = telepArea.colliders;
        ////colliderList.Clear();
        ////colliderList.Add(telepCollider);
        //objectCollider = this.gameObject.AddComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
