using UnityEngine;

public class MouseOverOutline : MonoBehaviour
{
    [SerializeField]
    private Outline outline;
    public void Hovering()
    {
        Debug.Log("isHovering");
        outline.enabled = true;
    }
    public void NotHovering()
    {
        outline.enabled = false;
    }
}
