using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySpawnerScript : MonoBehaviour
{
    public float interval = 0.1f;
    private float currentTime;
    public float XMin;
    public float XMax;
    public float YMin;
    public float YMax;
    public float ZMin;
    public float ZMax;

    public Vector3[] spawnPoints;
    public GameObject[] toSpawn;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time + interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MyGameManager.gm || MyGameManager.gm.gameOver || Time.time<currentTime)
        {
            return;
        }
        else if(SceneManager.GetActiveScene().name=="Level1")
        {
            currentTime = Time.time + interval;
            float x = Random.Range(XMin, XMax);
            float y = Random.Range(YMin, YMax);
            float z = Random.Range(ZMin, ZMax);
            int toSpawn1 = Random.Range(0, toSpawn.Length);
            Vector3 positiontoSpawn = new Vector3(x, y, z);
            GameObject newObj = Instantiate(toSpawn[toSpawn1], positiontoSpawn, transform.rotation);
            newObj.transform.parent = GameObject.Find("Spawner").transform;
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            currentTime = Time.time + interval;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length<2 && transform.childCount<1)
            {
                int spawnLoc = Random.Range(0, spawnPoints.Length);
                GameObject newObj = Instantiate(toSpawn[0],spawnPoints[spawnLoc], transform.rotation);
                newObj.transform.parent = GameObject.Find(gameObject.name).transform;
            }
        }
    }
}
