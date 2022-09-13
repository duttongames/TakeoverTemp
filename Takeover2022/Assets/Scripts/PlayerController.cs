using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 direction;
    public float speed = 8;
    public float jumpforce = 10;
    public float gravity = -20;

    public Transform groundCheck;
    public LayerMask groundLayer;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        direction.x = horInput * speed;

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpforce;
            }
        }
      


        controller.Move(direction * Time.deltaTime);
    }
}
