using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;

public class NotePadScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject taskCheckBoxPrefab;

    [SerializeField]
    private Transform checkBoxHolder;

    [SerializeField, ReadOnly]
    private List<GameObject> taskGameObjects;

    public void SetupTasks()
    {
        if (taskGameObjects.Count > 0) return;
        for(int i = 0; i < TaskManager._Instance.AvailableTasks.Length; i++)
        {
            taskGameObjects.Add(GameManager.Instantiate(taskCheckBoxPrefab, checkBoxHolder));
            taskGameObjects[i].GetComponent<CheckToggle>().CheckMark.enabled = false;
            taskGameObjects[i].GetComponent<CheckToggle>().TextBox.text = TaskManager._Instance.AvailableTasks[i];
        }
    }
    
    public void TaskComplete(int index)
    {
        taskGameObjects[index].GetComponent<CheckToggle>().CheckMark.enabled = true;
    }
}
