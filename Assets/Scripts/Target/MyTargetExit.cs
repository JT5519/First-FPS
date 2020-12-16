using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTargetExit : MonoBehaviour
{

    public float destroyAfterSeconds = 10f;
    public float afterAnimationExit = 1f;
    private float destroyTime;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        destroyTime = Time.time + destroyAfterSeconds;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= destroyTime)
        {
            anim.SetTrigger("Exit");
            Invoke("DestroyTarget", afterAnimationExit);
        }
    }
    void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
