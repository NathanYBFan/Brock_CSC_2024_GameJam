using NaughtyAttributes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region SerializeFields
    [Header("Movement")]
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private Rigidbody rigidBody;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private GameObject PlayerRoot;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private Transform orientation;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private float moveSpeed;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private bool canMove;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("")]
    private Vector3 move;

    [Header("GroundCheck")]
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private float playerHeight;

    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private LayerMask whatIsGround;

    [SerializeField, ReadOnly]
    [Foldout("Dependencies"), Tooltip("")]
    private bool isGrounded;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private float groundDrag;
    #endregion

    #region Private Variables
    private Vector3 moveDirection = Vector3.zero;
    #endregion

    private void Start()
    {
        if (rigidBody == null)
            transform.parent.GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }
    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector2.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        if (isGrounded) rigidBody.drag = groundDrag;
        else rigidBody.drag = 0;
    }

    private void FixedUpdate()
    {
        if (!canMove || !GameManager._Instance.InGame) return;

        move = PlayerInputSystem._Instance.GetMove();
        move.Normalize();

        moveDirection = orientation.forward * move.z + orientation.right * move.x;

        rigidBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        if (moveDirection == Vector3.zero) rigidBody.velocity = new Vector3(0, rigidBody.velocity.y, 0);
    }
}
