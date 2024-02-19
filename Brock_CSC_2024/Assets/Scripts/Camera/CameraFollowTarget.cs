using NaughtyAttributes;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    // Serialize Fields
    [SerializeField, Required]
    [Foldout("Dependencies"), Tooltip("")]
    private Transform cameraPosition;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = cameraPosition.position;
    }
}
