using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float value;

    public void SetValue(float number)
    {
        value = number;
    }
    public void UpdateValue(float number)
    {
        value += number;
    }

    public void SetImageFillAmount(Image img)
    {
        img.fillAmount = value;
    }
}