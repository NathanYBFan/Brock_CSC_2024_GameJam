using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverOutline : MonoBehaviour
{
    [SerializeField]
    private Outline outline;

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
