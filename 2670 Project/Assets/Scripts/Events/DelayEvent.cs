using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayEvent : MonoBehaviour
{
    public UnityEvent waitForEvent;
    private WaitForSeconds delay;
    private float waitTime;

    private void Start()
    {
        delay = new WaitForSeconds(waitTime);
    }

    private IEnumerator Wait()
    {
        yield return delay;
        waitForEvent.Invoke();
    }
}
