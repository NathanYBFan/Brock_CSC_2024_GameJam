using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    // Singleton Instantiation
    public static InventoryUI _Instance;

    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Inventory slots available for use")]
    private GameObject[] inventorySlots = new GameObject[4];

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private bool a;

    // Getters
    public GameObject[] InventorySlots { get { return inventorySlots; } }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a duplicated InventoryUI Singleton");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

    public bool AddItemToInventory(Item itemToAdd)
    {
        if (itemToAdd == null) return false;
        foreach (GameObject inventorySlot in inventorySlots)
        {
            InventorySlot inventorySlotTemp = inventorySlot.GetComponent<InventorySlot>();
            if (!inventorySlotTemp.ContainsAnItem)
                return inventorySlotTemp.AddItem(itemToAdd);
        }
        return false;
    }
}
