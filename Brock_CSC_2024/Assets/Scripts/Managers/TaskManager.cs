using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager _Instance;

    [SerializeField]
    private string[] availableTasks;

    [SerializeField]
    private NotePadScreen notePadScreen;

    [SerializeField]
    private int[] scoreAssignedToTasks;

    [SerializeField]
    private List<GameObject> garbageCans;

    [SerializeField]
    private List<GameObject> dishesToCleanUp;

    [SerializeField]
    private List<Cans> emptyCans;

    public List<Cans> EmptyCans { get { return emptyCans; } set { emptyCans = value; } }
    public List<GameObject> DishesToCleanUp { get { return dishesToCleanUp; } set { dishesToCleanUp = value; } }
    public List<GameObject> GarbageCans { get { return garbageCans; } set { garbageCans = value; } }
    public string[] AvailableTasks { get { return availableTasks; } }

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

    private void Start()
    {
        scoreAssignedToTasks = new int[availableTasks.Length];
        notePadScreen.SetupTasks();
    }
    
    public void TaskComplete(int index)
    {
        // Visual
        notePadScreen.TaskComplete(index);
        // Add score
        PlayerStatsManager._Instance.IncreasePoints(scoreAssignedToTasks[index]);
    }

    public void HighlightGarabageCan(bool onOrOff)
    {
        foreach (GameObject garbageCan in garbageCans)
            garbageCan.GetComponent<Outline>().enabled = onOrOff;
    }
    
    public void CleanedUpDish(GameObject dish)
    {
        dishesToCleanUp.Remove(dish);
        if (dishesToCleanUp.Count <= 0)
            TaskComplete(2);
    }

    public void CleanedUpCan(Cans can)
    {
        emptyCans.Remove(can);
        if (emptyCans.Count <= 0)
            TaskComplete(1);
    }
}
