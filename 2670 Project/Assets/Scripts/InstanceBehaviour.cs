using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class InstanceBehaviour : MonoBehaviour
{
    public GameAction gameActionObj;
    public GameObject prefab;
    public float holdTime = 0.5f;
    public bool canLoop;
    public UnityEvent startEvent, onCallEvent;
    private WaitForSeconds wfs;
    
    private void Start()
    {
        wfs = new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }
    
    public void StartLoopEvents()
    {
        StartCoroutine(CallInstanceEvent());
    }
    
    private IEnumerator CallInstanceEvent()
    {
        while (canLoop)
        {
            onCallEvent.Invoke();
            yield return wfs;
        }
    }
    
    public void Instance()
    {
        var location = transform.position;
        var newObj = Instantiate(prefab);
    }
}