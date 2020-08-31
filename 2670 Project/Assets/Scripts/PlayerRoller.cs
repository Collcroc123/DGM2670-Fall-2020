using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoller : MonoBehaviour
{
    private Rigidbody ball;
    private Vector3 movement;
    private float currentSpeed = 2f;
    private float gravity = 1f;
    private float jumpForce = 50f;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }
/*
    void OnMove(InputValue movementValue)
    {
        Vector3 movementVector = movementValue.Get<Vector3>();
    }*/

    void Update()
    {
        movement.x = Input.GetAxis("Vertical")*currentSpeed;
        movement.z = Input.GetAxis("Horizontal")* -currentSpeed;
        ball.AddForce(movement);
        
        if (Input.GetButtonDown("Jump"))
        {
            //Jump();
        }
        
        //movement.y -= gravity;
    }

    IEnumerator Jump()
    {
        movement.y = jumpForce;
        yield return new WaitForSeconds(1f);
        movement.y = 0f;
    }
}
