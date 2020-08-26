using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public IntData score;

    private void Start()
    {
        GetComponent<Text>().text = score.value.ToString();
    }
}
