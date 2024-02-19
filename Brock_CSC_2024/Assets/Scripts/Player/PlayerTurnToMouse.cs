using NaughtyAttributes;
using UnityEngine;

public class PlayerTurnToMouse : MonoBehaviour
{
    // Serialize Fields
    [SerializeField, ReadOnly]
    [Foldout("Dependencies"), Tooltip("The position of the mouse")]
    private Vector3 mousePos;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Pivot to turn on the player to face the mouse")]
    private Transform playerCenterPivot;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Rigidbody used to detect collisions and move")]
    private Rigidbody2D rigidBody2D;

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        playerCenterPivot.transform.up = (mousePos - new Vector2(playerCenterPivot.position.x, playerCenterPivot.position.y)) * Time.deltaTime;
    }
}
