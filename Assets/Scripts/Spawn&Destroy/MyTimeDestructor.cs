using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
