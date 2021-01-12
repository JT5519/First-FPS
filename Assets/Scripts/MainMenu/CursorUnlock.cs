using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to unlock cursor from game
public class CursorUnlock : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }  
}
