using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Assertions;

public class CM_FadeTeleportationManager : TeleportationProvider
{
    public float fadeSpeed;
    public RawImage fader;

    private float timer;

    void Start()
    {

    }

    IEnumerator FadeIn(TeleportRequest teleportRequest)
    {
        timer = 0;

        while (timer < 1)
        {
            fader.color = Color.Lerp(Color.clear, Color.black, timer);
            timer += fadeSpeed;
            yield return new WaitForEndOfFrame();
        }

        currentRequest = teleportRequest;
        validRequest = true;
    }

    IEnumerator FadeOut()
    {
        timer = 0;

        while (timer < 1)
        {
            fader.color = Color.Lerp(Color.black, Color.clear, timer);
            timer += fadeSpeed;
            yield return new WaitForEndOfFrame();
        }

        EndLocomotion();
    }

    public override bool QueueTeleportRequest(TeleportRequest teleportRequest)
    {
        StartCoroutine(FadeIn(teleportRequest));

        return true;
    }

    protected override void Update()
    {
        if (!validRequest || !BeginLocomotion())
        {
            return;
        }

        var xrOrigin = base.system.xrOrigin;
        if (xrOrigin != null)
        {
            switch (currentRequest.matchOrientation)
            {
                case MatchOrientation.WorldSpaceUp:
                    xrOrigin.MatchOriginUp(Vector3.up);
                    break;
                case MatchOrientation.TargetUp:
                    xrOrigin.MatchOriginUp(currentRequest.destinationRotation * Vector3.up);
                    break;
                case MatchOrientation.TargetUpAndForward:
                    xrOrigin.MatchOriginUpCameraForward(currentRequest.destinationRotation * Vector3.up, currentRequest.destinationRotation * Vector3.forward);
                    break;
                default:
                    Assert.IsTrue(condition: false, string.Format("Unhandled {0}={1}.", "MatchOrientation", currentRequest.matchOrientation));
                    break;
                case MatchOrientation.None:
                    break;
            }

            Vector3 b = xrOrigin.Origin.transform.up * xrOrigin.CameraInOriginSpaceHeight;
            Vector3 desiredWorldLocation = currentRequest.destinationPosition + b;
            xrOrigin.MoveCameraToWorldLocation(desiredWorldLocation);
        }


        StartCoroutine(FadeOut());

        validRequest = false;
    }




}