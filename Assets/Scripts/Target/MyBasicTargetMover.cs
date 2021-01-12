using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//movement of targets in level 1
public class MyBasicTargetMover : MonoBehaviour
{
    public enum motionDirections {Spin,Horizontal,Vertical};
    public motionDirections motionState = motionDirections.Horizontal;
    public float spinSpeed = 180f;
    public float motionMagnitude = 0.1f;
    public bool doSpin = true;
    public bool doMove = true;
    void Update()
    {
       switch(motionState)
        {
            //spin with constant speed
            case motionDirections.Spin:
                transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime, Space.Self);
                break;
            //cos fluctuates between -1 and 1 so the movememnt fluctuates trigonometrically
            case motionDirections.Horizontal:
                transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude,Space.Self);
                break;
            case motionDirections.Vertical:
                transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude, Space.Self);
                break;

        }
    }
}
