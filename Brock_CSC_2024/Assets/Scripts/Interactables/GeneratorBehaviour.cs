using UnityEngine;

public class GeneratorBehaviour : Interactable
{
    public override void InteractedWith()
    {
        TaskManager._Instance.TaskComplete(0);
    }

    public override void ApplyEffect()
    {
        return;
    }
}
