using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void ContinueButtonPressed()
    {
        GameManager._Instance.StartNewGame();
        LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[2]);
    }
}
