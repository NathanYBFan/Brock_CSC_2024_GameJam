using UnityEngine;

public class Garbage : Item
{
    public override void Use(RaycastHit2D hit)
    {
        Debug.Log("Used " + NameOfInteractable);
    }
}
