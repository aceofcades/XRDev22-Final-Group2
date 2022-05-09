using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FW_TriggerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("01 collision enter" + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("02 collision stay" + collision.gameObject.name);

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("03 collision exit" + collision.gameObject.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("01 trigger enter" + other.gameObject.name);

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("02 trigger stay" + other.gameObject.name);

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("03 trigger exit" + other.gameObject.name);

    }
}
