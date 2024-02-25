using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager _Instance;

    [SerializeField]
    private string[] availableTasks;

    [SerializeField]
    private List<GameObject> garbageCans;

    [SerializeField]
    private List<GameObject> sinks;

    [SerializeField]
    private List<GameObject> shelves;

    [SerializeField]
    private List<Dishes> dishesToCleanUp;

    [SerializeField]
    private List<Paper> paperToCleanUp;

    [SerializeField]
    private List<Cans> emptyCans;
    
    [SerializeField]
    private int[] scoreAssignedToTasks;

    [SerializeField]
    private NotePadScreen notePadScreen;

    public List<Paper> PaperToCleanUp { get { return paperToCleanUp; } set { paperToCleanUp = value; } }
    public List<Cans> EmptyCans { get { return emptyCans; } set { emptyCans = value; } }
    public List<Dishes> DishesToCleanUp { get { return dishesToCleanUp; } set { dishesToCleanUp = value; } }
    public List<GameObject> GarbageCans { get { return garbageCans; } set { garbageCans = value; } }
    public List<GameObject> Sinks { get { return sinks; } set { sinks = value; } }
    public List<GameObject> Shelves { get { return shelves; } set { shelves = value; } }
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

    public void HighlightSinks(bool onOrOff)
    {
        foreach (GameObject sink in sinks)
            sink.GetComponent<Outline>().enabled = onOrOff;
    }

    public void HighlightShelf(bool onOrOff)
    {
        foreach (GameObject shelf in shelves)
            shelf.GetComponent<Outline>().enabled = onOrOff;
    }

    public void CleanedUpCan(Cans can)
    {
        emptyCans.Remove(can);
        if (emptyCans.Count <= 0)
            TaskComplete(1);
    }

    public void CleanedUpDish(Dishes dish)
    {
        dishesToCleanUp.Remove(dish);
        if (dishesToCleanUp.Count <= 0)
            TaskComplete(2);
    }

    public void CleanedUpPaper(Paper paper)
    {
        paperToCleanUp.Remove(paper);
        if (paperToCleanUp.Count <= 0)
            TaskComplete(3);
    }
}
