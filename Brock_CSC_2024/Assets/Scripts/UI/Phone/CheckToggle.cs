using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckToggle : MonoBehaviour
{
    [SerializeField]
    private Image checkmark;

    [SerializeField]
    private TextMeshProUGUI textBox;

    public Image CheckMark { get { return checkmark; } }
    public TextMeshProUGUI TextBox { get { return textBox; } }
}
