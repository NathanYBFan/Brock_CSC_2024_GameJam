using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private string textToAdd = "Date ETA: ";

    [SerializeField]
    private TextMeshProUGUI textBox;

    private void Update()
    {
        if (GameManager._Instance == null) return;
        textBox.text = textToAdd + GameManager._Instance.Timer.ToString("F1");
    }
}
