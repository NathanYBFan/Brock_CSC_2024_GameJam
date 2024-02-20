using UnityEngine;

public class PlayerLeftClick : MonoBehaviour
{
    public void OnLeftClickDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Make sure something was hit
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity)) return;

        // Call scripts if available
        if (hit.transform.gameObject.GetComponent<Interactable>())
            hit.transform.gameObject.GetComponent<Interactable>().InteractedWith();
        else if (hit.transform.gameObject.GetComponent<Item>())
            hit.transform.gameObject.GetComponent<Item>().PickUpItem();
    }
}
