using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyRotate : MonoBehaviour
{
    public enum AxisToRotateAround {X,Y,Z};
    public AxisToRotateAround axis = AxisToRotateAround.X;
    public float rotateSpeed;
    private void Update()
    {
        Vector3 directionToRotate=Vector3.right;
        switch(axis)
        {
            case AxisToRotateAround.X:
                directionToRotate = Vector3.right;
                break;
            case AxisToRotateAround.Y:
                directionToRotate = Vector3.up;
                break;
            case AxisToRotateAround.Z:
                directionToRotate = Vector3.forward;
                break;
        }
        transform.Rotate(directionToRotate * rotateSpeed * Time.deltaTime);
    }
}
