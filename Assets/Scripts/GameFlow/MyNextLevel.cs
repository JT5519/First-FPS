using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNextLevel : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            MyGameManager.gm.NextLevel();
        }
    }
}
