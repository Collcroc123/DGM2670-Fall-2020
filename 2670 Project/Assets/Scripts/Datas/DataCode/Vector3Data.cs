using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValueVector3(Vector3 obj)
    {
        value = obj;
    }
    
    public void SetValuePosition(Transform obj)
    {
        value = obj.position;
    }

    public void SetPositionValue(Transform obj)
    {
        obj.position = value;
    }

    public void SetValueRotation(Transform obj)
    {
        value = obj.eulerAngles;
    }

    public void SetFromMousePosition(Camera cam)
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hit, 100))
        {
            value = hit.point;
        }
    }
}