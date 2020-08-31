using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private Vector3 rotateMovement;
    private float gravity = 4.9f;
    private float currentSpeed = 5f;
    public float rotateSpeed = 5f;
    public float moveSpeed = 5f;
    public float sprintSpeed = 7.5f;
    public float jumpForce = 50f;
    public int maxJumps = 1;
    public int jumpCount;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        rotateMovement.y = Input.GetAxis("Mouse X")*rotateSpeed;
        transform.Rotate(rotateMovement);
        movement.x = Input.GetAxis("Vertical")*currentSpeed;
        movement.z = Input.GetAxis("Horizontal")* -currentSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            movement.y = jumpForce;
        }
        
        if (controller.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity;
        }
        
        controller.Move(movement*Time.deltaTime);
    }
}
