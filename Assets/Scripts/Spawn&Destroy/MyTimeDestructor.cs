using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//timed destructor for coins in level 1
public class MyTimeDestructor : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeOut = 2f;
    void Awake()
    {
        Invoke("SelfDestruct", timeOut);
    }

    // Update is called once per frame
    void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
