using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 value;

    public void SetValueTransform(Vector3 obj)
    {
        value = obj;
    }

    public void SetValueRotation(Transform obj)
    {
        value = obj.eulerAngles;
    }
}
