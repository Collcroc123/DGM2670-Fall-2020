using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    
    private float moveSpeed = 7.5f, rotateSpeed = 180f, gravity = -9.81f, jumpForce = 5f;
    private float yVar;
    
    private int JumpCountMax = 2, jumpCount;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var vInput = Input.GetAxis("Vertical") * moveSpeed;
        movement.Set(vInput, yVar, 0);

        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
        transform.Rotate(0,hInput,0);

        yVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            jumpCount = 0;
            yVar = -1f;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < JumpCountMax)
        {
            yVar += jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement*Time.deltaTime);
    }
}
