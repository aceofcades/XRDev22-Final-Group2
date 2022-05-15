using System.Collections;
using UnityEngine;

public class DR_ThumbstickTrackpadRotator : MonoBehaviour
{
    public DR_ThumbstickTrackpadButtonWatcher watcher;
    public Vector3 rotationAngle = new Vector3(0, 45, 0);
    public float rotationDuration = 0.25f; // seconds
    private Quaternion startingRotation;
    private Quaternion rotateTo;
    private Coroutine rotator;

    private void Start()
    {
        watcher.thumbstickTrackpadButtonPress.AddListener(onButtonEvent);
        startingRotation = this.transform.rotation;
        rotateTo =  Quaternion.Euler(rotationAngle) * startingRotation;
    }

    public void onButtonEvent(bool pressed)
    {
        if (rotator != null)
            StopCoroutine(rotator);
        if (pressed)
        {
            rotator = StartCoroutine(AnimateRotation(this.transform.rotation, rotateTo));
        }        
        //else
        //    rotator = StartCoroutine(AnimateRotation(this.transform.rotation, offRotation));
    }

    private IEnumerator AnimateRotation(Quaternion fromRotation, Quaternion toRotation)
    {
        float t = 0;
        while (t < rotationDuration)
        {
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, t / rotationDuration);
            t += Time.deltaTime;
            yield return null;
        }

        // set up for next rotation
        startingRotation = this.transform.rotation;
        rotateTo = Quaternion.Euler(rotationAngle) * startingRotation;
    }
}
