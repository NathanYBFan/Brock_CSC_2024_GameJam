using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField]
    private GameObject doorToPivot;

    [SerializeField]
    private int openDegrees = 120;

    [SerializeField]
    private int closeDegrees = 0;

    [SerializeField]
    private float rotateSpeed = 1;

    private bool isClosed = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        StopAllCoroutines();

        Quaternion adjustedRotation = doorToPivot.transform.rotation;

        if (isClosed) // If door is closed
            adjustedRotation *= Quaternion.Euler(0, 0, openDegrees);
        else
            adjustedRotation *= Quaternion.Euler(0, 0, closeDegrees);

        StartCoroutine(RotateDoor(doorToPivot.transform.rotation, adjustedRotation));
        isClosed = !isClosed;
    }

    private IEnumerator RotateDoor(Quaternion start, Quaternion destination)
    {
        float fraction = 0;
        while (doorToPivot.transform.rotation != destination)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * rotateSpeed;
                doorToPivot.transform.rotation = Quaternion.Lerp(start, destination, fraction);
            }
            else
                doorToPivot.transform.rotation = destination;
            yield return null;
        }
        yield break;
    }
}
