using NaughtyAttributes;
using UnityEngine;

public class PlayerTurnToMouse : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField]
    [Tooltip("Camera being used to see the character")]
    private Camera mainCamera;

    [Foldout("Script Dependancies")]
    [SerializeField]
    [Tooltip("The object to rotate")]
    private Transform target;

    private LayerMask floorLayerMask; // Layer mask to only care about the floor

    private void Start()
    {
        floorLayerMask = LayerMask.GetMask("Ground");
    }
    private void LateUpdate()
    {
        if (!GameManager._Instance.InGame) return;
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        if (Time.timeScale == 0f) return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f, floorLayerMask))
        {
            Vector3 spinToPoint = hitInfo.point;
            spinToPoint.y = target.position.y;
            target.transform.LookAt(spinToPoint);
        }
    }
}
