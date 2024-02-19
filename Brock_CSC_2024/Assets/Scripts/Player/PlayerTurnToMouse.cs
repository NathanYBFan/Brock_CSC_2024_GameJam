using NaughtyAttributes;
using UnityEngine;

public class PlayerTurnToMouse : MonoBehaviour
{
# region SerializeFields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("")]
    private Transform orientation;

    [SerializeField]
    [Foldout("Stats"), Tooltip("")]
    private Vector2 mouseSensitivity = Vector2.one;
    #endregion

    private float yRotation, xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseSensitivity.x;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSensitivity.y;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate camera and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
