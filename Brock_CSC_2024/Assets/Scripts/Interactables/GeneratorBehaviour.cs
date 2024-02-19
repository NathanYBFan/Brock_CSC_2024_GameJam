using UnityEngine;

public class GeneratorBehaviour : Interactable
{
    public override void InteractedWith()
    {
        Debug.Log("IT RUNS");
    }

    public override void ApplyEffect()
    {
        return;
        throw new System.NotImplementedException();
    }
}
