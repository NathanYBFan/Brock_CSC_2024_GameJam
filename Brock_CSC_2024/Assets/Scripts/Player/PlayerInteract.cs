using NaughtyAttributes;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Center of player to draw raycast from")]
    private Transform playerCenterPivot;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("The layers the raycast should interact with")]
    private LayerMask raycastLayer;

    [SerializeField]
    [Foldout("Stats"), Tooltip("The distance the player should be able to interact")]
    private float raycastDistance = 20f;

    // Private Variables
    private RaycastHit2D hit;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hit = Physics2D.Raycast(playerCenterPivot.position, mousePos - (Vector2)playerCenterPivot.position, raycastDistance, raycastLayer);

        if (hit.collider != null && !hit.collider.CompareTag("Player"))
        {
            //Debug.Log("Hit object: " + hit.collider.gameObject.name);
            Debug.DrawLine(playerCenterPivot.position, hit.point, Color.red);
        }
        else
        {
            //Debug.Log("No Object hit");
            Vector2 endPosition = (Vector2)transform.position + ((Vector2)transform.up * raycastDistance);
            Debug.DrawLine(playerCenterPivot.position, endPosition, Color.red);
        }
    }

    public void CheckForInteractable()
    {
        if (hit == false) return;
        if (hit.collider.CompareTag("Interactable"))
            hit.collider.GetComponent<Interactable>().InteractedWith();
        else if (hit.collider.CompareTag("Item"))
            hit.collider.GetComponent<Item>().PickUpItem();
    }
}
