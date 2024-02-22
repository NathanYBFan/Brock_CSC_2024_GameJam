using System.Collections.Generic;
using UnityEngine;

public class LockScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject notificationPrefab;

    [SerializeField]
    private Transform notificationHolder;

    [SerializeField]
    private List<GameObject> notifications;

    [SerializeField]
    private int messageMaxLength = 30;

    private void OnEnable()
    {
        for (int i = 0; i < NotificationManager._Instance.GetAllNotifications().Count; i++)
        {
            notifications.Add(GameObject.Instantiate(notificationPrefab, notificationHolder));
            string message = NotificationManager._Instance.GetAllNotifications()[i];
            if (message.Length < messageMaxLength)
                notifications[i].GetComponent<NotificationPopup>().TextBox.text = NotificationManager._Instance.GetAllNotifications()[i];
            else
                notifications[i].GetComponent<NotificationPopup>().TextBox.text = NotificationManager._Instance.GetAllNotifications()[i].Substring(0, messageMaxLength) + "...";
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < NotificationManager._Instance.GetAllNotifications().Count; i++)
            Destroy(notifications[i]);
        notifications.Clear();
    }
}
