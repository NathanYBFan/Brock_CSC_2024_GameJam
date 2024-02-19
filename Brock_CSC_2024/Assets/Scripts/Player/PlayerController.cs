using NaughtyAttributes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private Rigidbody2D m_Rigidbody2D;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private GameObject PlayerRoot;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private float moveSpeed;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private bool canMove;

    [SerializeField, Range(0, .3f)]
    [Foldout("Stats"), Tooltip("")]
    private float m_MovementSmoothing = .05f;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("")]
    private Vector3 move;

    // Private Variables
    private Vector3 m_Velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (!canMove) return;

        move = PlayerInputSystem._Instance.GetMove();

        // Move the character by finding the target velocity
        Vector3 targetVelocity = move * moveSpeed;
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
