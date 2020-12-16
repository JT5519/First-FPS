using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyEnemyHit : MonoBehaviour
{
    public int health = 5;
    public GameObject explosionPrefab;
    private TextMesh text;
    private void Start()
    {
        text = gameObject.transform.Find("health").GetComponent<TextMesh>();
        text.text = health.ToString("0");
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
        if(health<=0)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            MyGameManager.gm.ScoreAdd(10, 0f);
            Destroy(gameObject);
        }
    }
}
