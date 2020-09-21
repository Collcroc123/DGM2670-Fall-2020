using System;
using UnityEngine;
using UnityEngine.Events;

public class MouseEventsBehaviour : MonoBehaviour
{
    public UnityEvent mouseDownEvent, mouseUpEvent, mouseDragEvent;

    private void OnMouseDown()
    {
        mouseDownEvent.Invoke();
    }

    private void OnMouseUp()
    {
        mouseUpEvent.Invoke();
    }

    private void OnMouseDrag()
    {
        mouseDragEvent.Invoke();
    }
}
