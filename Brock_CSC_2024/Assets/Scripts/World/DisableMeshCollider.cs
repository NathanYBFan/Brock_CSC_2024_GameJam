using UnityEngine;
using UnityEngine.Rendering;

public class DisableMeshCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject opaqueParent;

    [SerializeField]
    private GameObject transparentParent;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        opaqueParent.SetActive(false);
        transparentParent.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        opaqueParent.SetActive(true);
        transparentParent.SetActive(false);
    }
}
