using UnityEngine;

public class LookAt : MonoBehaviour
{
    public void OnLook(Vector3Data obj)
    {
        transform.LookAt(obj.value);
        var y = obj.value.y -= 90;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
