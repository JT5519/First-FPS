using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to handle player shooting. Attached to camera container
public class MyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float projectileVelocity = 200f;
    public AudioClip SFX;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(bulletPrefab, transform.position +(transform.forward*0.1f), transform.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileVelocity, ForceMode.VelocityChange);
            AudioSource.PlayClipAtPoint(SFX, transform.position);
        }
    }
}
