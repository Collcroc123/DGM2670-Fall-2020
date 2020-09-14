using System;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var location = transform.position;
            var rotation = new Vector3(0,0,0);
            Instantiate(prefab, location, Quaternion.Euler(rotation));
        }
    }
}
