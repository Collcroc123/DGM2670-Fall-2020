using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 move = Vector3.left;
    void Update()
    {
        controller = GetComponent<CharacterController>();
        controller.Move(move * Time.deltaTime);
    }

    private IEnumerator KnockB(ControllerColliderHit hit)
    {
        var i = 2f;
        move = hit.collider.attachedRigidbody.velocity * i;
        while (i > 0)
        {
            yield return new WaitForFixedUpdate();
            i -= 0.1f;
        }
        move = Vector3.left;
    }

    public float pushPower = 10.0f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        StartCoroutine(KnockB(hit));
        var body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3)
        {
            return;
        }
        
        var pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        var forces = pushDir * pushPower;
        body.AddRelativeForce(forces);
        body.AddTorque(forces);
    }
}