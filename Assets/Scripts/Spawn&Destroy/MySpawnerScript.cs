using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*script that handles spawning of targets at random locations in the scene*/
public class MySpawnerScript : MonoBehaviour
{
    public float interval = 0.1f;
    private float currentTime; //time after which to spawn enemies 
    //ranges of spawn
    public float XMin;
    public float XMax;
    public float YMin;
    public float YMax;
    public float ZMin;
    public float ZMax;

    public Vector3[] spawnPoints; //used in Level2 only
    public GameObject[] toSpawn; //types of possible targets (Level1)
    void Start()
    {
        currentTime = Time.time + interval; 
    }

    void Update()
    {
        if (!MyGameManager.gm || MyGameManager.gm.gameOver || Time.time<currentTime)
        {
            return;
        }
        else if(SceneManager.GetActiveScene().name=="Level1")
        {
            currentTime = Time.time + interval; 
            //calculating random point to spawn at
            float x = Random.Range(XMin, XMax);
            float y = Random.Range(YMin, YMax);
            float z = Random.Range(ZMin, ZMax);
            int toSpawn1 = Random.Range(0, toSpawn.Length);
            Vector3 positiontoSpawn = new Vector3(x, y, z);
            //choosing one of the 4 target types to spawn
            GameObject newObj = Instantiate(toSpawn[toSpawn1], positiontoSpawn, transform.rotation);
            newObj.transform.parent = GameObject.Find("Spawner").transform; //spawning chosen object at chosen point
        }
        else if(SceneManager.GetActiveScene().name == "Level2")
        {
            currentTime = Time.time + interval;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length<2 && transform.childCount<1) //limiting enemies at a single moment, to 2
            {
                int spawnLoc = Random.Range(0, spawnPoints.Length); //choosing one out of allowed spawn points
                GameObject newObj = Instantiate(toSpawn[0],spawnPoints[spawnLoc], transform.rotation); //spawn object
                newObj.transform.parent = GameObject.Find(gameObject.name).transform; //enemies as child of spawner object
            }
        }
    }
}
