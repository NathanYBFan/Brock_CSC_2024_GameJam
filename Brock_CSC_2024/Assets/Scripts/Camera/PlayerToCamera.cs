using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToCamera : MonoBehaviour
{
    [Foldout("Script Dependancies")]
    [SerializeField]
    [Tooltip("Target to follow")]
    private Transform target;

    [Foldout("Camera Specs")]
    [SerializeField]
    [Tooltip("Offset for the camera to be at (From the target)")]
    Vector3 Offset = Vector3.zero;

    [Foldout("Camera Specs")]
    [SerializeField]
    [Range(0, 5)]
    [Tooltip("How much delay before the camera catches up with the player")]
    private float movementSmoothing = 0.25f;

    private Vector3 currentVelocity;    // Current move speed of the camera

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position + Offset, ref currentVelocity, movementSmoothing);
    }
}
