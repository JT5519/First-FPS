using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to set mouse sensitivity and inversion for game
public class MouseValues : MonoBehaviour
{
    public static float mouseX = 0.5f;
    public static float mouseY = 0.5f;
    public static bool invertY = false;
    public void setX(float x)
    {
        mouseX = x;
    }
    public void setY(float x)
    {
        mouseY = x;
    }
    public void setInvY(bool x)
    {
        invertY = x;
    }
}
