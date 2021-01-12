using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*script to recoil camera when player is hit. Acts as feedback to the player that they were hit.*/
public class MyCameraAnim : MonoBehaviour
{
    public Animator anim;
   void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void healthLoss() //camera recoils on hit
    {
        anim.SetTrigger("Hit");
    }
}
