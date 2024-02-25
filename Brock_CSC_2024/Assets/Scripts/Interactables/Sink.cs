using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Interactable
{
    public override void ApplyEffect()
    {
        return; // No effect
    }

    public override void InteractedWith()
    {
        Debug.Log("Interacted with Garbage Can");
        // If item is held, remove item
        // If no item is held, open garbage can menu?
    }

    void Start()
    {
        TaskManager._Instance.Sinks.Add(this.gameObject);
    }

}
