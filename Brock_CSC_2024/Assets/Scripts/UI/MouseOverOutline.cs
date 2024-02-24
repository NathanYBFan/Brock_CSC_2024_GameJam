using UnityEngine;

public class MouseOverOutline : MonoBehaviour
{
    [SerializeField]
    private Outline outline;
    public void Hovering()
    {
        outline.enabled = true;
    }
    public void NotHovering()
    {
        outline.enabled = false;
    }
}
