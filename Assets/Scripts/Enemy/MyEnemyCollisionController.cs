using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyCollisionController : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
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
