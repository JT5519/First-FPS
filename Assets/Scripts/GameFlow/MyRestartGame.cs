using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to restart game from main menu
public class MyRestartGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MyGameManager.gm.RestartGame();
    }
}
