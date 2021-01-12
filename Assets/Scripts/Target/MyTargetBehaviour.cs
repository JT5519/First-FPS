using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to handle target explosions on being hit
public class MyTargetBehaviour : MonoBehaviour
{
    public GameObject TargetExplosionPrefab;
    public int scoreAdd;
    public float timeAdd;
    private void OnCollisionEnter(Collision collision)
    {
        if(!MyGameManager.gm || MyGameManager.gm.gameOver)
        {
            return;
        }
        if(collision.collider.tag=="Projectile")
        {
            if(TargetExplosionPrefab) //explode target and add score
            {
                Instantiate(TargetExplosionPrefab, transform.position,transform.rotation);
            }
            MyGameManager.gm.ScoreAdd(scoreAdd, timeAdd);
            Destroy(gameObject);
        }
    }
}
