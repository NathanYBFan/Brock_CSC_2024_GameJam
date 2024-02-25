using UnityEngine;

public class Sink : Interactable
{
    public override void ApplyEffect()
    {
        return; // No effect
    }

    public override void InteractedWith()
    {
        Debug.Log("Interacted with Sink");
    }

    void Start()
    {
        TaskManager._Instance.Sinks.Add(this.gameObject);
    }

}
