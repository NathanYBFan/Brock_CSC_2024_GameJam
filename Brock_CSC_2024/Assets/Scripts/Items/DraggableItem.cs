using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Root object to move")]
    private Transform rootObject;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Image to adjust")]
    private Image image;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Saved item")]
    private Item itemItIs;

    [SerializeField]
    [Foldout("Stats"), Tooltip("Bool to check if item should be destroyed on use")]
    private bool destroyOnUse = true;

    // Private Variables
    private Transform parentAfterDrag;

    // Public Getters & Setters
    public Transform ParentAfterDrag { get { return parentAfterDrag; } set { parentAfterDrag = value; } }
    public Item ItemItIs { get { return itemItIs; } set { itemItIs = value; } }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Remove item from inventory slot
        transform.parent.parent.GetComponent<InventorySlot>().RemoveItem();
        
        // Set parent
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);

        // Put at front
        transform.SetAsLastSibling();
        
        // Invisible to raycast
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rootObject.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
        if (!CheckForInteraction(hit)) return;

        // Confirm presence in inventory slot
        parentAfterDrag.transform.parent.GetComponent<InventorySlot>().MoveItem(itemItIs);
        
        // Set parent fully
        transform.SetParent(parentAfterDrag);

        // Visible to raycast
        image.raycastTarget = true;
    }

    private bool CheckForInteraction(RaycastHit2D hit)
    {
        // If raycast hits something
        if (!hit == true || !hit.transform.CompareTag("ItemInteractable")) return false;
        
        // Use item
        itemItIs.Use(hit);
        // If shouldnt destroy on use return true to continue 
        if (!destroyOnUse) return true;
        
        // Destroy object and return false to not continue
        Destroy(rootObject.gameObject);
        return false;
    }
}
