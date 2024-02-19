using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("The slider to adjust the value of")]
    private Slider loadingSlider;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private Color fillColor;

    private void OnEnable()
    {
        loadingSlider.value = 0;
        loadingSlider.fillRect.GetComponent<Image>().color = fillColor;
    }

    // Update slider values
    public void UpdateSlider(float value)
    {
        float progressAmount = Mathf.Clamp01(value / 0.9f); // Normalize to correct value
        loadingSlider.value = progressAmount;
    }
}