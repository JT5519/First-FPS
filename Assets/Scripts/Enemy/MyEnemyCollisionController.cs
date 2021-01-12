using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*code to handle bullets hitting enemies. Making the enemies kinematic permanently, made them pass through the walls (static colliders)
  placed on the map. The work around was to make them kinematic only for the moment a bullet from the player hits them*/ 
public class MyEnemyCollisionController : MonoBehaviour
{
    Rigidbody rb; //enemy rigidbody
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision) //objects that an enemy can collide with
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Projectile" || collision.collider.tag == "Enemy")
        {
            rb.isKinematic = true;
        }
    }
    private void OnCollisionExit(Collision collision) 
    {
           rb.isKinematic = false;
    }
}
