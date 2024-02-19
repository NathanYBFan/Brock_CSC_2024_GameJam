using NaughtyAttributes;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class UnlockedDoor : MonoBehaviour
{
    // THis doesnt work, Needs new process
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private Transform doorRootObject;

    //[SerializeField]
    //[Foldout("Stats"), Tooltip("")]
    //private float speed = 2f;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private bool isOpen = false;

    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        inDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        inDoor = false;
    }

    private void Update()
    {
        if (!inDoor) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            // Smoothly interpolate between the current rotation and the target rotation
            if (isOpen) {
                isOpen = false;
            }
            else{
                isOpen = true;
            }
        }
    }
}
