using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script to handle player being hit
public class PlayerHit : MonoBehaviour
{
    MyCameraAnim cam;
    public int health = 20;
    public Text healthText;
    private void Awake()
    {
         cam = Camera.main.GetComponent<MyCameraAnim>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(MyGameManager.gm.gameOver)
        {
            return;
        }
        if (collision.collider.tag == "Projectile")
        {
            cam.healthLoss();
            health--;
            if(health<0)
            {
                health = 0;
            }
            healthText.text = health.ToString("0");
        }
    }
    private void Update()
    {
        if(health<=0)
        {
            MyGameManager.gm.playerDead();
        }
    }
}
