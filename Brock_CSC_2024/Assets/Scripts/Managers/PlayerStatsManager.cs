using NaughtyAttributes;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    // Singleton Initialization
    public static PlayerStatsManager _Instance;

    #region SerializeFields
    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("Array of points for each player")]
    private int playerPoints;
    #endregion

    #region Setters&Getters
    public int PlayerPoints { get { return playerPoints; } set { playerPoints = value; } }
    #endregion

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a repeated PlayerStatsManager");
            Destroy(this.gameObject);
        }

        else if (_Instance == null)
            _Instance = this;
    }

    public void ResetStats()
    {
        playerPoints = 0;
    }

    public void IncreasePoints(int amount)
    {
        playerPoints += amount;
        CheckWinCondition();
    }

    // Check to see if any player has met the win condition
    private void CheckWinCondition()
    {

    }

    private void WinConditionMet()
    {
        
    }
}
