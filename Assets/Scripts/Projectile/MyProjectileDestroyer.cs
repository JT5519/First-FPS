using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyProjectileDestroyer : MonoBehaviour
{
    public float timeOut = 2f;
    public GameObject explosionPrefab;
    void Awake()
    {
        Invoke("SelfDestruct", timeOut);
    }

    // Update is called once per frame
    void SelfDestruct()
    {
        if (gameObject)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       Instantiate(explosionPrefab, transform.position, transform.rotation);
        SelfDestruct();
    }
}
