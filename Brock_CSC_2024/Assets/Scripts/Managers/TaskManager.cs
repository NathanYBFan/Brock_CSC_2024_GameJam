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
        Debug.Log(availableTasks[index]);
        // Add score
        PlayerStatsManager._Instance.IncreasePoints(scoreAssignedToTasks[index]);
    }
}
