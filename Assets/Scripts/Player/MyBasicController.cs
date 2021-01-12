using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*player controller*/
public class MyBasicController : MonoBehaviour
{
    private CharacterController cc;
    private Vector3 Movement;
    public float moveSpeed = 30f;
    public float gravity = 9.81f;
    private void Start()
    {
        cc = GetComponent<CharacterController>();

    }
    void Update()
    {
        Movement = ((Input.GetAxis("Horizontal") * moveSpeed * transform.right) + (Input.GetAxis("Vertical") * moveSpeed * transform.forward)) * Time.deltaTime;
        Movement.y -= gravity * Time.deltaTime;
        cc.Move(Movement);
    }
}
