using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FW_TelepArea : MonoBehaviour
{
    public bool IsWithinMazeBox { get; set; } = false;
    public bool test;
    private TeleportationArea telepAreaComponent;

    private void Start()
    {
        telepAreaComponent = this.GetComponent<TeleportationArea>();
    }
    private void Update()
    {
        test = IsWithinMazeBox;
        if (IsWithinMazeBox == true)
        {
            telepAreaComponent.enabled = false;
        }
        else
        {
            telepAreaComponent.enabled = true;
        }
    }
}
