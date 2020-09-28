using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Vector3Data vData;
    
    private void OnTriggerEnter(Collider other)
    {
        vData.SetValueVector3(transform.position);
    }
}