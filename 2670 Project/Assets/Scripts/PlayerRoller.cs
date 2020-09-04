using UnityEngine;

public class PlayerRoller : MonoBehaviour
{
    private Rigidbody ball;
    private Vector3 movement;
    private float currentSpeed = 3f;
    private float maxSpeed = 30f;
    private float gravity = 0f;
    private float jumpForce = 5f;
    private bool grounded;
    public bool speedLimit = true;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Vertical")*currentSpeed;
        movement.z = Input.GetAxis("Horizontal")* -currentSpeed;
        
        if (gravity > -1f)
        {
            gravity += -0.01f;
            //gravity = -1f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            gravity = 0f;
            gravity += jumpForce;
        }
        movement.y = gravity;
        ball.AddForce(movement);
        //Debug.Log(gravity);
        if (ball.velocity.magnitude > 40f)
        {
            if (speedLimit)
            {
                ball.velocity = ball.velocity.normalized * maxSpeed;
                //Debug.Log("Too Fast!!!");
            }
        }
    }
}