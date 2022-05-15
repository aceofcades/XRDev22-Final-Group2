using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is used for matahing position XZ to main camera's position
/// </summary>
public class FW_CharacterBodyManagement : MonoBehaviour
{
    public GameObject cameraMain;   // link to Main Camera
    public GameObject head;     // link to head
    
    private FW_CameraManagement headCode;    // link to head
    private CapsuleCollider body;

    // Start is called before the first frame update
    void Start()
    {
        headCode = head.GetComponent<FW_CameraManagement>();
        body = this.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (headCode.IsInTrigger == false)
        {
            float positionY = this.transform.position.y;
            this.transform.position = new Vector3(cameraMain.transform.position.x, positionY, cameraMain.transform.position.z);
        }
        bodyHeightAdjustment();
    }

    public void bodyHeightAdjustment()
    {
        float headBottom;
        // get head height
        headBottom = head.transform.position.y - this.transform.position.y - head.GetComponent<SphereCollider>().radius - 0.02f;
        // calculate body height and center
        body.height = headBottom;
        body.center = new Vector3(0, headBottom / 2 + 0.01f, 0);
    }
}
