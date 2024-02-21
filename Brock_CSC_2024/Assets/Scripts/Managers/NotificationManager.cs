using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public static NotificationManager _Instance;

    [SerializeField]
    private List<string> notificationMessages;

    [SerializeField]
    private Phone phone;
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a repeated GameManager");
            Destroy(this.gameObject);
        }

        else if (_Instance == null)
            _Instance = this;
    }

    public void AddNotificationMessage(string message)
    {
        notificationMessages.Add(message);
        phone.UpdateNotificationDisplay();
    }
    public List<string> GetAllNotifications()
    {
        return notificationMessages;
    }

}
