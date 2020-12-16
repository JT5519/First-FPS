using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyShooterAuto : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject sparkPrefab;
    public float projectileVelocity = 200f;
    public AudioClip SFX;
    public float shootAfter = 2f;
    private float shootTime;
    int layerMask;
    GameObject playa;

    public GameObject Life;
    private void Start()
    {
        shootTime = Time.time + shootAfter;
        layerMask = LayerMask.GetMask("Player", "Default");
        playa = GameObject.FindGameObjectWithTag("Player");
        Life.SetActive(false);
    }
    void Update()
    {
        if(MyGameManager.gm.gameOver)
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, FindDirection(),out hit, 80f, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.tag == "Player")
            {
                Life.SetActive(true);
                if (Time.time > shootTime)
                {
                    Instantiate(sparkPrefab, transform.position, transform.rotation);
                    GameObject projectile = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
                    projectile.GetComponent<Rigidbody>().AddForce(transform.forward * projectileVelocity, ForceMode.VelocityChange);
                    AudioSource.PlayClipAtPoint(SFX, transform.position);
                    shootTime = Time.time + shootAfter;
                }
            }
            else
            {
                Life.SetActive(false);
            }
        }
    }
    Vector3 FindDirection()
    {
        Vector3 playerPoint = playa.transform.position;
        Vector3 myPoint = transform.position;
        return playerPoint-myPoint;
    }
}
