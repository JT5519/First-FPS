using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBasicController : MonoBehaviour
{
    // Update is called once per frame
    private CharacterController cc;
    private Vector3 Movement;
    public float moveSpeed = 30f;
    public float gravity = 9.81f;
    public bool collidedWithEnemy = false;
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
