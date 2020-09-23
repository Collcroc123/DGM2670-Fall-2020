using UnityEngine;

[CreateAssetMenu]
public class Debugger : ScriptableObject
{
    public void OnDebug(string txt)
    {
        Debug.Log(txt);
    }
}
