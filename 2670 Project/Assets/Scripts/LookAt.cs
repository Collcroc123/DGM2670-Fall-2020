using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform lookObj;

    private void Look()
    {
        transform.LookAt(lookObj);
        var transformRotation = transform.eulerAngles;
        transformRotation.x = 0;
        transformRotation.y = 0;
        transform.rotation = Quaternion.Euler(transformRotation);

    }
}
