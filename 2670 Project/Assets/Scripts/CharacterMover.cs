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
            jumpCount = 0;
            yVar = -1f;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < maxJump.value)
        {
            yVar = jumpForce;
            jumpCount++;
        }

        movement = transform.TransformDirection(movement);
        controller.Move(movement*Time.deltaTime);
    }
}
