using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this class is used to manage the camera
/// when trigger with others
/// 1. fade out
/// </summary>
public class FW_CameraManagement : MonoBehaviour
{
    public float fadeOpacity = 0.8f;
    public float fadeProcessTime = 2;
    public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0,0), new Keyframe(1,1));
    public GameObject fadeBoard;

    public bool IsInTrigger { get; set; } = false;

    private float alpha = 0;
    private Texture2D texture;
    private float fadeTiming;

    private bool fadeOutStart = false;  // start to be black view
    private bool fadeInStart = false;   // start to go back to normal view
    private bool fadeOnGoing = false;   // fade process status
    private Image fadeBoardImage;

    public void Reset()
    {
        alpha = 0;
        fadeTiming = 0;
        fadeOutStart = false;
        fadeInStart = false;
        fadeOnGoing = false;
    }

    private void Start()
    {
        fadeCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, fadeOpacity));
        fadeBoardImage = fadeBoard.GetComponent<Image>();
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            //Reset();
            fadeOutStart = true;
            fadeInStart = false;
            fadeOnGoing = true;

            IsInTrigger = true;
        }
        //Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            fadeOutStart = false;
            fadeInStart = true;
            fadeOnGoing = true;

            IsInTrigger = false;
        }
    }

    private void Update()    // OnGUI doesn't work for VR...
    {
        if (fadeOnGoing != true) return;

        // Create black texture on camera
        if (texture == null)
            texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(0, 0, 0, alpha));
        texture.Apply();    // allpy the SetPixel changes
        if (fadeOutStart)
            fadeTiming += Time.deltaTime / fadeProcessTime;
        else if(fadeInStart)
            fadeTiming -= Time.deltaTime / fadeProcessTime;
        alpha = fadeCurve.Evaluate(fadeTiming);
        fadeBoardImage.color = new Color(0, 0, 0, alpha);
        //Debug.Log(fadeBoardImage.color.a);
        
        if (fadeTiming >= 1)
            fadeTiming = 1;
        if (fadeTiming <= 0)
        {
            fadeTiming = 0;
            fadeInStart = false;
        }
        if (fadeOutStart == false && fadeInStart == false)
        {
            fadeOnGoing = false;
        }
    }
}
