using System.Collections;
using UnityEngine;

public class PlayerRoller : MonoBehaviour
{
    private Rigidbody ball;
    private Vector3 movement;
    private float currentSpeed = 3f;
    private float gravity = 1f;
    private float jumpForce = 50f;
    private bool grounded;
    
    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Vertical")*currentSpeed;
        movement.z = Input.GetAxis("Horizontal")* -currentSpeed;
        ball.AddForce(movement);
        
        if (Input.GetButtonDown("Jump"))
        {
            //Jump();
        }
    }
    
    IEnumerator Jump()
    {
        movement.y = jumpForce;
        yield return new WaitForSeconds(1f);
        movement.y = 0f;
    }
    
    /*
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Bababooey");
        if(other.collider.CompareTag("Ground"))
        {
            movement.y = 0;
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpForce;
            }
        }
        else
        {
            movement.y -= gravity;
        }
    }*/
}

