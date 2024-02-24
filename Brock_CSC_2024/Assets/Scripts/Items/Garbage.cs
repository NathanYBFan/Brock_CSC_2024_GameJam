using UnityEngine;

public class Garbage : Item
{
    public override void Use(RaycastHit hit)
    {
        Debug.Log("Used " + NameOfInteractable);
    }
}
