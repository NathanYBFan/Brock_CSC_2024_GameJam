using NaughtyAttributes;
using System.Collections;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField]
    private GameObject phoneUI;

    [SerializeField]
    private GameObject phoneObject;

    [SerializeField]
    private Transform[] phonePositions;

    [SerializeField]
    private float speed;

    [SerializeField, ReadOnly]
    private int notifCount = 0;

    [SerializeField]
    private TextMeshProUGUI notifTextbox;

    private void Start()
    {
        phoneUI.SetActive(false);
        phoneObject.transform.position = phonePositions[0].position; // Up
        notifCount = 0;
        UpdateNotificationDisplay();
    }

    public void OnPressOnPhone()
    {
        // Set active proper menus
        phoneUI.SetActive(!phoneUI.activeSelf);
        
        // Position Phone
        if (phoneUI.activeSelf)
            StartCoroutine(LerpPhonePosition(phoneObject.transform.position, phonePositions[1].position)); // Up
        else
            StartCoroutine(LerpPhonePosition(phoneObject.transform.position, phonePositions[0].position)); // Down
    }

    public IEnumerator LerpPhonePosition(Vector3 startPos, Vector3 endPos)
    {
        float fraction = 0;
        while (phoneObject.transform.position != endPos)
        {
            if (fraction < 1)
            {
                fraction += Time.deltaTime * speed;
                phoneObject.transform.position = Vector3.Lerp(startPos, endPos, fraction);
            }
            else
                phoneObject.transform.position = endPos;
            yield return null;
        }
        yield break;
    }

    public void GetNotification(int numberOfNotifs)
    {
        notifCount += numberOfNotifs;
        UpdateNotificationDisplay();
    }

    private void UpdateNotificationDisplay()
    {
        if (notifCount < 0) notifCount = 0;
        if (notifCount == 0) notifTextbox.text = "";
        else notifTextbox.text = notifCount.ToString();
    }
}
