using System;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    public Vector3Data rotationDirection;

    private void Instance()
    {
        var location = transform.position;
        Instantiate(prefab, location, Quaternion.Euler(rotationDirection.value));
    }
}
