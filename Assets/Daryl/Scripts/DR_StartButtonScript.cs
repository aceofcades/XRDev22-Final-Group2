using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DR_StartButtonScript : MonoBehaviour
{
    private int n;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        n++;
        Debug.Log("Button clicked " + n + " times.");
    }
}
