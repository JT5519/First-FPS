using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyMouseLooker1 : MonoBehaviour
{
    public float XSensitivity = 2f;
    public float YSensitivity = 2f;
    //reference to transforms of the player and camera
    private Transform playerTransform;
    private Transform cameraTransform;
    //camera rotation in local space
    private Quaternion cameraRotation;

    private Animation anim;
    public int invertMouseY = 1;
    private void Awake()
    {
        XSensitivity = MouseValues.mouseX;
        YSensitivity = MouseValues.mouseY;
        if (MouseValues.invertY)
            invertMouseY = -1;
        else
            invertMouseY = 1;
    }
    void Start()
    {
        CursorLock(true);
        playerTransform = transform;
        cameraTransform = Camera.main.transform;
        cameraRotation = cameraTransform.localRotation;
        anim = Camera.main.GetComponent<Animation>();
    }
    void CursorLock(bool isLocked)
    {
        if(isLocked)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            CursorLock(false);
        }
        else
        {
            CursorLock(true);
        }
        LookUpdateMahMan();
    }
    void LookUpdateMahMan()
    {
        float yRot = Input.GetAxis("Mouse X")*XSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * YSensitivity*invertMouseY;

        cameraRotation *= Quaternion.Euler(-xRot, 0, 0);
        cameraRotation = ClampCamRotation(cameraRotation);

        playerTransform.localRotation = Quaternion.Slerp(playerTransform.localRotation, playerTransform.localRotation * Quaternion.Euler(0, yRot, 0), 1);
        cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation,cameraRotation, 1);

    }
    Quaternion ClampCamRotation(Quaternion x)
    {
        Quaternion temp = x;
        float angleX = x.eulerAngles.x;
        if(angleX>90 && angleX<100)
        {
            angleX = 90f;
        }
        else if(angleX<270 && angleX>260)
        {
            angleX = 270f;
        }
        x = Quaternion.Euler(angleX, temp.y, temp.z);
        return x;
    }
}
