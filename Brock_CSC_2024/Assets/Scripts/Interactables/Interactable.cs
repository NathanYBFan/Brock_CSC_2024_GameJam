using NaughtyAttributes;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Collider attached to the interactable gameobject")]
    private Collider2D objectMainCollider;

    [SerializeField]
    [Foldout("Stats"), Tooltip("Name assigned to the interactable")]
    private string nameOfInteractable;

    public abstract void InteractedWith();
    public abstract void ApplyEffect();

}
