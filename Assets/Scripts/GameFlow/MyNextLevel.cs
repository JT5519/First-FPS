using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script attached to next level textmesh object to play next level
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
