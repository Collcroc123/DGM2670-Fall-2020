using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocation : MonoBehaviour
{
    private Camera cam;
    public Vector3Data locationData;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            locationData.SetValueVector3(hit.point);
        }
    }
}
