﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayAgain : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Projectile")
        {
            MyGameManager.gm.PlayAgainGame();
        }
    }
}
