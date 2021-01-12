using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to make enemy autoshoot
public class MyShooterAuto : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject sparkPrefab;
    public float projectileVelocity = 200f;
    public AudioClip SFX;
    public float shootAfter = 2f; //time between consecutive shots
    private float shootTime;
    int layerMask; //for raycast
    GameObject playa;

    public GameObject Life;
    private void Start()
    {
        shootTime = Time.time + shootAfter;
        layerMask = LayerMask.GetMask("Player", "Default"); //raycast should only hit player and default layer elements, not UI etc
        playa = GameObject.FindGameObjectWithTag("Player");
        Life.SetActive(false);
    }
    void Update()
    {
        if(MyGameManager.gm.gameOver)
        {
            return;
        }
        /*raycast shot from enemy towards player, if anything detected in the way, it means there is an obstruction and hence enemy will not shoot*/
        RaycastHit hit;
        if (Physics.Raycast(transform.position, FindDirection(),out hit, 80f, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.tag == "Player")
            {
                /*if enemy can see player, player can also see enemy, only then should enemy health bar be visible above enemies head
                   else the health bar gives away enemies position when obstructions are in the way. This makes play more suspensful.*/
                Life.SetActive(true);
                if (Time.time > shootTime) //shoot
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
    Vector3 FindDirection() //find direction vector between player and enemy
    {
        Vector3 playerPoint = playa.transform.position;
        Vector3 myPoint = transform.position;
        return playerPoint-myPoint;
    }
}
