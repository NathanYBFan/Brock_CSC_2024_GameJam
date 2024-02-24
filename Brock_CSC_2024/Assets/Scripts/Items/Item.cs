using NaughtyAttributes;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Object Origin")]
    private GameObject itemRootObject;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Object Origin")]
    private Sprite inventoryDisplayImage;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Object Origin")]
    private GameObject inventoryDisplayItem;

    [SerializeField]
    [Foldout("Stats"), Tooltip("Name assigned to the item")]
    private string nameOfInteractable;

    // Getters
    public string NameOfInteractable { get { return nameOfInteractable; } }
    public Sprite InventoryDisplayImage { get { return inventoryDisplayImage; } }
    public GameObject ItemRootObject { get { return itemRootObject; } }
    public GameObject InventoryDisplayItem { get { return inventoryDisplayItem; } }


    public abstract void Use(RaycastHit hit);
    public void PickUpItem()
    {
        if (InventoryUI._Instance.AddItemToInventory(this))
            Destroy(this.gameObject);
    }
}
