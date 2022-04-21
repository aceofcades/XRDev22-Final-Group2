using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// for testing
/// Method: if bool = true, Rotation with x (Qua or Euler) in y time (second)
/// </summary>
public class FW_RotationControl_test : MonoBehaviour
{
    public GameObject cube;
    public bool rotationTriggerOn = false;
    public bool rotationOn = false;
    public Vector3 rotationAngle = new Vector3(90, 0, 0);
    public float timeOfRotation = 5f;     // 5 second
    public Quaternion cubeRotationOrigin;
    public Quaternion cubeRotationFinal;
    public float timeCounting = 0;

    // Start is called before the first frame update
    void Start()
    {
        cube = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // trigger to get existing rotation
        if (rotationTriggerOn)
        {
            RotationTriggerStart();
        }

        // if it's on, start the rotation process
        if (rotationOn)
        {
            float lerpTime = timeCounting / timeOfRotation;
            cube.transform.rotation = Quaternion.Lerp(cubeRotationOrigin, cubeRotationFinal, lerpTime);
            //cube.transform.rotation *= Quaternion.Euler(rotationAngle * Time.deltaTime / timeOfRotation);
            if (timeCounting > timeOfRotation)
            {
                rotationOn = false;
            }
            timeCounting += Time.deltaTime;
        }
    }

    public void RotationTriggerStart()
    {
        // reset timeCounting
        timeCounting = 0;
        // get all the data
        cubeRotationOrigin = cube.transform.rotation;
            //Debug.Log(cubeRotationOrigin.eulerAngles);
        cubeRotationFinal = cubeRotationOrigin * Quaternion.Euler(rotationAngle);
            //Debug.Log(cubeRotationFinal.eulerAngles);
        // formally turn on the rotation
        rotationOn = true;
        // turn off the rotationTrigger
        rotationTriggerOn = false;
    }
}
