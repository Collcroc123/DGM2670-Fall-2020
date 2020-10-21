using UnityEngine;

[CreateAssetMenu]
public class StateMachine : ScriptableObject
{
    public enum States
    {
        Walk,
        Sprint,
        Idle
    }
    
    public States value;
    //public UnityEvent;

    public void Walk()
    {
        
    }

    public void Sprint()
    {
        
    }

    public void Idle()
    {
        
    }
}
