using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPlayer : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 direction;
    public float speed = 8;
    public float altspeed = 10;
    public float jumpforce = 10;
    public float altjumpforce = 15;
    public float gravity = -20;
    public float terminalvel = -50;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public enum PowerupState {none, invincible, speedup, jumpboost, infjumps, doublepoint, laser}
    public PowerupState currentpower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        if (currentpower == PowerupState.speedup)
        {
            direction.x = horInput * altspeed;
        }
        else
        {
            direction.x = horInput * speed;
        }

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        if (currentpower == PowerupState.infjumps)
        {
            isGrounded = true;
        }
        direction.y += gravity * Time.deltaTime;
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (currentpower == PowerupState.jumpboost)
                {
                    direction.y = altjumpforce;
                }
                else
                {
                    direction.y = jumpforce;
                }
            }
        }

        if (direction.y <= terminalvel) 
        {
            direction.y = terminalvel;
        }
      


        controller.Move(direction * Time.deltaTime);
    }
}
