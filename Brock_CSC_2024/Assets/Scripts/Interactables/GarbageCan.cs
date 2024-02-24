using UnityEngine;

public class GarbageCan : Interactable
{
    [SerializeField]
    private int garbageCanCapasity;

    private void Start()
    {
        TaskManager._Instance.GarbageCans.Add(this.gameObject);
    }

    public override void ApplyEffect()
    {
        return; // No effect
    }

    public override void InteractedWith()
    {
        // If item is held, remove item
        // If no item is held, open garbage can menu?
    }
}
