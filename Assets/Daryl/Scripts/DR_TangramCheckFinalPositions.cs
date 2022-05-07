using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DR_TangramCheckFinalPositions : MonoBehaviour
{
    [SerializeField]
    MeshRenderer currentObject;

    DR_LevelManager _levelManager;

    Quaternion orangeTriangleDesiredRotation = new Quaternion(90f, -135f, 0f, 1f);
    Quaternion orangeTriangleDesiredPosition = new Quaternion(1.195f, 0.985f, -0.133f, 1f);

    Quaternion greenSquareDesiredRotation = new Quaternion(90f, 0f, 0f, 1f);
    Quaternion greenSquareDesiredPosition = new Quaternion(0.841f, 0.985f, 0.273f, 1f);

    Quaternion blueParalellogramDesiredRotation = new Quaternion(90f, 0f, 225f, 1f);
    Quaternion blueParalellogramDesiredPosition = new Quaternion(0.711f, 0.985f, 0.05f, 1f);

    Quaternion yellowTriangleDesiredRotation = new Quaternion(90f, 180f, -90f, 1f);
    Quaternion yellowTriangleDesiredPosition = new Quaternion(0.805f, 0.985f, -0.224f, 1f);

    Quaternion pinkTriangleDesiredRotation = new Quaternion(90f, 0f, 225f, 1f);
    Quaternion pinkTriangleDesiredPosition = new Quaternion(0.95f, 0.985f, 0.101f, 1f);

    Quaternion fuschiaTriangleDesiredRotation = new Quaternion(90f, 180f, -135f, 1f);
    Quaternion fuschiaTriangleDesiredPosition = new Quaternion(0.972f, 0.985f, -0.214f, 1f);

    Quaternion cyanTriangleDesiredRotation = new Quaternion(90f, 0f, 45f, 1f);
    Quaternion cyanTriangleDesiredPosition = new Quaternion(0.833f, 0.985f, -0.469f, 1f);

    // we will need to figure out a way to restict rotation of the Z axis to increments of 45 degrees
    //  int[] angles = new int[] { 0, 45, 90, 135, 180, 225, 270, 315 };

    private void FlipHorizontal()
    {
        // since we have frozen the tangram tiles' rotation in the x and y dimension,
        //  we need to add a method to "flip" the object over either horizontally or vertically

        int currentZ = Mathf.FloorToInt(gameObject.transform.rotation.z);
        int currentEighth = currentZ % 15; 
        float newZ = currentEighth == 7 ? newZ = 0f : (float)(currentEighth + 1) * 15;

        gameObject.transform.Rotate(0f, 0f, newZ);
    }

    private void OnTangramMoved()
    {
        CheckTangramPosition();
    }

    private void CheckTangramPosition()
    {

    }

    private void Start()
    {
        currentObject.transform.hasChanged = false;
    }

    private void Update()
    {

        if (currentObject.transform.hasChanged)
        {
            Quaternion whereItIsNow = currentObject.transform.rotation;
            // figure out which object this is
            switch (currentObject.name)
            {
                case "OrangeTriangle":
                    {
                        if (whereItIsNow  == orangeTriangleDesiredRotation)
                        {
                            _levelManager.AddObjectRotationOk(currentObject);                            
                        }
                        else
                        {
                            _levelManager.RemoveObjectRotationOk(currentObject);
                        }
                        break;
                    }
                case "GreenSquare":
                    {
                        break;
                    }
                case "BlueParalellogram":
                    {
                        break;
                    }
                case "YellowTriangle":
                    {
                        break;
                    }
                case "PinkTriangle":
                    {
                        break;
                    }
                case "FushiaTriangle":
                    {
                        break;
                    }
                case "CyanTriangle":
                    {
                        break;
                    }
                default:
                    {
                        Debug.LogWarning(currentObject.name);
                        break;
                    }
            }
        }
    }
}
