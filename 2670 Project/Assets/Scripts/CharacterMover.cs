using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement;
    private Vector3 rotateMovement;
    private float gravity = 0.5f;
    private float currentSpeed = 5f;
    public float rotateSpeed = 5f;
    public float moveSpeed = 5f;
    public float sprintSpeed = 7.5f;
    public float jumpForce = 5f;
    //public int maxJumps = 1;
    //public int jumpCount;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
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

        if (controller.isGrounded)
        {
            movement.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpForce;
                Debug.Log("JUMPED!");
            }
        }
        else
        {
            movement.y -= gravity;
        }
        
        controller.Move(movement*Time.deltaTime);
    }
}
