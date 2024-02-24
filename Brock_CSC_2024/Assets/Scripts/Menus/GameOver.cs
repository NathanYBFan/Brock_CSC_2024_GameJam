using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBox;

    private void Start()
    {
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
