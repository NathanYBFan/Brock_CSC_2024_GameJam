using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationPopup : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBox;

    public TextMeshProUGUI TextBox { get { return textBox; } set { textBox = value; } } 
}
