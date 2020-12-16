using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRestartGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MyGameManager.gm.RestartGame();
    }
}
