using NaughtyAttributes;
using UnityEngine;

public class KeyCard : Item
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Stats"), Tooltip("Color assigned to keypass")]
    private KeyCardColors keyPassColor;

    // Getters
    public KeyCardColors KeyPassColor { get { return keyPassColor; } }

    public override void Use(RaycastHit2D hit)
    {

        Debug.Log("Granting Access");
    }
}
