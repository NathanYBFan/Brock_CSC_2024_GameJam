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

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private LayerMask layerMask;


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

        TaskManager._Instance.HighlightGarabageCan(true);

        // Invisible to raycast
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rootObject.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TaskManager._Instance.HighlightGarabageCan(false);

        if (!CheckForInteraction()) return;

        // Confirm presence in inventory slot
        parentAfterDrag.transform.parent.GetComponent<InventorySlot>().MoveItem(itemItIs);
        
        // Set parent fully
        transform.SetParent(parentAfterDrag);

        // Visible to raycast
        image.raycastTarget = true;
    }

    private bool CheckForInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If raycast hits something
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) || !hit.transform.CompareTag("GarbageCan")) return true;

        // Use item
        itemItIs.Use(hit);
        // If shouldnt destroy on use return true to continue 
        if (!destroyOnUse) return true;

        parentAfterDrag.transform.parent.GetComponent<InventorySlot>().RemoveItem();

        // Destroy object and return false to not continue
        Destroy(rootObject.gameObject);
        return false;
    }
}
