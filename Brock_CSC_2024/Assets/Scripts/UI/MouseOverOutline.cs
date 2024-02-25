using UnityEngine;

public class MouseOverOutline : MonoBehaviour
{
    [SerializeField]
    private Outline outline;
    
    private void Start()
    {
        NotHovering();
    }

    public void Hovering()
    {
        outline.enabled = true;
    }
    public void NotHovering()
    {
        outline.enabled = false;
    }
}
