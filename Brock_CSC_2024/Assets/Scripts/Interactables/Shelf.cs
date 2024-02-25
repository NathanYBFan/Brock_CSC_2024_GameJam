using UnityEngine;

public class Shelf : Interactable
{
    [SerializeField]
    private Outline outline;
    public override void ApplyEffect()
    {
        return; // No effect
    }

    public override void InteractedWith()
    {
        Debug.Log("Interacted with Shelf");
    }

    void Start()
    {
        TaskManager._Instance.Shelves.Add(this.gameObject);
        outline.enabled = false;
    }
}
