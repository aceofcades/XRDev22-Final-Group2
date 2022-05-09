using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_TeleportationAreaManagement : MonoBehaviour
{
    public static FW_TeleportationAreaManagement singleton;

    public GameObject telepArea;    // link to TeleportationArea_2x2

    private List<GameObject> listOfTelepAreas = new List<GameObject>();
    // this one is used to store all TelepArea
    private GameObject maze;    // this is the parent
    private Quaternion lastRotation;
    private bool mazeIsRotating = false;

    private void Awake()
    {
        singleton = this;
        maze = this.transform.parent.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastRotation = maze.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // if maze is rotating, stop Teleportation until it's stationary
        if (maze.transform.rotation != lastRotation && mazeIsRotating == false)
        {
            RemoveTelepArea();
            mazeIsRotating = true;
        }

        if (maze.transform.rotation == lastRotation && mazeIsRotating == true)
        {
            AddTelepArea();
            mazeIsRotating = false;
        }
        lastRotation = maze.transform.rotation;
    }

    public void AddTelepArea()
    {
        if (this.transform.lossyScale == new Vector3(1, 1, 1))
            // add condition, so handy maze will not add Teleportation Area
        {
            foreach (Transform child in this.transform.GetComponentsInChildren<Transform>())
            {
                if (child.GetComponent<BoxCollider>() != null)
                {
                    GameObject telepAreaInstance = Instantiate(telepArea, child);
                    Vector3 position = child.gameObject.GetComponent<BoxCollider>().center;
                    telepAreaInstance.transform.localPosition = position;
                    telepAreaInstance.transform.rotation = Quaternion.Euler(0, 0, 0);

                    // add all telp Area into a list for future easier management
                    listOfTelepAreas.Add(telepAreaInstance);
                }
            }

            // detect overlap telep area and destroy
            //foreach (GameObject item in listOfTelepAreas)
            //{
            //    if (item.GetComponent<FW_TelepArea>().IsWithinMazeBox == true)
            //    {
            //        listOfTelepAreas.Remove(item);
            //        Destroy(item);
            //    }
            //}

            Debug.Log("Teleportation Areas are added~");
        }
    }

    public void RemoveTelepArea()
    {
        foreach (GameObject item in listOfTelepAreas)
        {
            Destroy(item);
        }
        listOfTelepAreas.Clear();
        Debug.Log("Teleportation Areas are removed~");
    }
}
