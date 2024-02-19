using NaughtyAttributes;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    // Serialize Fields
    [SerializeField, Required]
    [Foldout("Dependencies"), Tooltip("")]
    private GameObject targetToFollow;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private Vector3 cameraOffset = new Vector3(0,0,-10);

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private float dampTime = 0.15f;

    // Private Variables
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPosition = targetToFollow.transform.position;
        cameraPosition += cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, dampTime);
    }
}
