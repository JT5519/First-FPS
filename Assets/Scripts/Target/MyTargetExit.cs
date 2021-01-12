using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script to handle auto target destruction after a while, in level 1
public class MyTargetExit : MonoBehaviour
{

    public float destroyAfterSeconds = 10f; //target lifetime
    public float afterAnimationExit = 1f;
    private float destroyTime;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        destroyTime = Time.time + destroyAfterSeconds;
    }

    void Update()
    {
        if (Time.time >= destroyTime)
        {
            anim.SetTrigger("Exit"); //target shrinks so that exit looks seamless
            Invoke("DestroyTarget", afterAnimationExit); //destroyed after a second
        }
    }
    void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
