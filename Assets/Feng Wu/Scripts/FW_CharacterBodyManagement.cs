using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this class is used for matahing position XZ to main camera's position
/// </summary>
public class FW_CharacterBodyManagement : MonoBehaviour
{
    public GameObject cameraMain;   // link to Main Camera
    public FW_CameraManagement head;    // link to head

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (head.IsInTrigger == false)
        {
            float positionY = this.transform.position.y;
            this.transform.position = new Vector3(cameraMain.transform.position.x, positionY, cameraMain.transform.position.z);
        }
    }
}
