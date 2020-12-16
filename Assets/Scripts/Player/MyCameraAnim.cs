using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraAnim : MonoBehaviour
{
    public Animator anim;
   void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void healthLoss()
    {
        anim.SetTrigger("Hit");
    }
}
