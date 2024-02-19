using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[2], true);
        LevelLoadManager._Instance.StartNewGame();
    }

    public void SettingsButtonPressed()
    {
        LevelLoadManager._Instance.LoadMenuOverlay(LevelLoadManager._Instance.LevelNamesList[1]);
    }

    public void QuitButtonPressed()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
