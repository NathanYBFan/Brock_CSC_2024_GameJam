using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsDisplay;

    [SerializeField]
    private TextMeshProUGUI textBox;

    private void Start()
    {
        pointsDisplay.text = "Your Points: " + PlayerStatsManager._Instance.PlayerPoints.ToString();

        if (PlayerStatsManager._Instance.PlayerPoints >= PlayerStatsManager._Instance.PointsNeededToWin)
            textBox.text = "You win!";
        else
            textBox.text = "Lose :(";
    }
    public void ContinueButtonPressed()
    {
        LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[0]);
    }
    
}
