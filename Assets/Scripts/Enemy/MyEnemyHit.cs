using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//script to handle damage to enemies
public class MyEnemyHit : MonoBehaviour
{
    public int health = 5;
    public GameObject explosionPrefab; //enemy death
    private TextMesh text; //health shown as text
    private void Start()
    {
        text = gameObject.transform.Find("health").GetComponent<TextMesh>();
        text.text = health.ToString("0"); // "0" species format as an integer
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (MyGameManager.gm.gameOver)
        {
            return;
        }
        if (collision.collider.tag=="Projectile")
        {
            if (health > 0)
            {
                health--;
                text.text = health.ToString("0");
            }
        }
    }
    private void Update()
    {
        if(health<=0) //when enemy dies, explode and add score
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation); 
            MyGameManager.gm.ScoreAdd(10, 0f);
            Destroy(gameObject);
        }
    }
}
