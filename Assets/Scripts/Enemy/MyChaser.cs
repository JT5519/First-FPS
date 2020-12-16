using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyChaser : MonoBehaviour
{
    GameObject target;
    Rigidbody rb;
    public float moveSpeed;

    GameObject Gun;
    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
        Gun = transform.Find("Gun Casing").gameObject;
    }
    void FixedUpdate()
    {
        if(!target || !Gun || MyGameManager.gm.gameOver)
        {
            return;
        }
        else if(transform.position.y>1.5f)
        {
            return;
        }
        else
        {
            transform.LookAt(target.transform);
            Gun.transform.LookAt(target.transform);
            if(Vector3.Distance(target.transform.position,transform.position)>5f)
            {
                rb.MovePosition(transform.position+(moveSpeed*Time.deltaTime*transform.forward));
            }
        }
    }
}
