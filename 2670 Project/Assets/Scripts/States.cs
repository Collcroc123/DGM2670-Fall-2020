using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class States : MonoBehaviour
{
    private CharacterController controller;

    public StateMachine characterStates;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        switch (characterStates.value)
        {
            case StateMachine.States.Walk:
                print("Walk");
                break;
            case StateMachine.States.Sprint:
                print("Run");
                break;
            case StateMachine.States.Idle:
                print("Idle");
                break;
        }
    }
}