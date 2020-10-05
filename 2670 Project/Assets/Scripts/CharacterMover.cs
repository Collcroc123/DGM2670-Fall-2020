using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    public FloatData moveSpeed, normalSpeed, fastSpeed;
    private Vector3 movement;
    private float yVar, rotateSpeed = 180f, gravity = -9.81f, jumpForce = 5f;
    public IntData maxJump;
    private int jumpCount;
    public Vector3Data currentSpawn;
    
    
    private void Start()
    {
        moveSpeed = normalSpeed;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = fastSpeed;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = normalSpeed;
        }
        
        var vInput = Input.GetAxis("Vertical") * moveSpeed.value;
        movement.Set(vInput, yVar, 0);

        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
        transform.Rotate(0,hInput,0);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount = 0;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement*Time.deltaTime);
    }
    
    private Vector3 direction = Vector3.zero;
    public float pushPower = 3f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var body = hit.collider.attachedRigidbody;

        if (body == null)
        {
            return;
        }
        
        direction.Set(hit.moveDirection.x, 0, hit.moveDirection.z);
        var pushDirection = direction * pushPower;
        body.velocity = pushDirection;
    }

    private void OnEnable()
    {
        transform.position = currentSpawn.value;
    }
}
