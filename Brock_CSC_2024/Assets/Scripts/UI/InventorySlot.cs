using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Textbox holding the inventory slot number")]
    private TextMeshProUGUI numberTextBox;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Inventory Slot Background Image")]
    private Image inventorySlotBG;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("The location to display the item stored")]
    private Transform itemDisplayPosition;

    [SerializeField]
    [Foldout("Stats"), Tooltip("Inventory Number to assigned")]
    private int inventoryNumber;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("Inventory Number to assigned")]
    private Item itemHeld;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("bool if an item exists in the inventory slot")]
    private bool containsAnItem;

    [SerializeField]
    [Foldout("Adaptables"), Tooltip("Text color")]
    private Color numberTextColor = new Color(255, 255, 255, 255);

    [SerializeField]
    [Foldout("Adaptables"), Tooltip("Text color")]
    private Color inventorySlotColor = new Color(87, 87, 87, 255);

    // Getters
    public bool ContainsAnItem { get { return containsAnItem; } set { containsAnItem = value; } }

    private void OnEnable()
    {
        numberTextBox.text = inventoryNumber.ToString();
        numberTextBox.color = numberTextColor;
        inventorySlotBG.color = inventorySlotColor;
        containsAnItem = false;
    }

    // Spawn a new item in slot
    public bool AddItem(Item itemToAdd)
    {
        if (containsAnItem) return false;

        containsAnItem = true;

        itemHeld = itemToAdd;

        GameObject item = GameObject.Instantiate(itemToAdd.InventoryDisplayItem, Vector3.zero, Quaternion.identity, itemDisplayPosition);
        item.GetComponent<DraggableItem>().ItemItIs = itemToAdd;

        return true;
    }

    // Move item from another slot to this slot
    public void MoveItem(Item itemToAdd)
    {
        if (containsAnItem) return;

        containsAnItem = true;
        
        itemHeld = itemToAdd;
    }

    // Remove the item in the current slot
    public void RemoveItem()
    {
        containsAnItem = false;
        itemHeld = null;
    }

    // If a object is dropped onto this inventory slot
    public void OnDrop(PointerEventData eventData)
    {
        if (containsAnItem) return;
        GameObject dropped = eventData.pointerDrag;
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.ParentAfterDrag = itemDisplayPosition;
    }
}
