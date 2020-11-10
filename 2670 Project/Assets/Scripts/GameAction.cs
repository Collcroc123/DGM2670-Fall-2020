using UnityEngine;
using UnityEngine.Events;

public class GameAction : ScriptableObject
{
    public UnityAction action;
    public UnityAction<Transform> transformAction;

    public void Raise()
    {
        action?.Invoke();
    }

    public void Raise(Transform obj)
    {
        transformAction(obj);
    }
}