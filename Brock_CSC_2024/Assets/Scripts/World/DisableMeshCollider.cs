using UnityEngine;
using UnityEngine.Rendering;

public class DisableMeshCollider : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] meshRendererArray;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        foreach(MeshRenderer mr in meshRendererArray)
            mr.shadowCastingMode = ShadowCastingMode.ShadowsOnly;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        foreach (MeshRenderer mr in meshRendererArray)
            mr.shadowCastingMode = ShadowCastingMode.On;
    }
}
