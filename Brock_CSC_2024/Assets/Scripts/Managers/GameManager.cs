using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Singleton Initialization
	public static GameManager _Instance;

    #region SerializeFields
    [SerializeField]
	[Foldout("Dependencies"), Tooltip("Pause Menu GameObject")]
	private GameObject pauseMenu;

    [SerializeField]
	[Foldout("Dependencies"), Tooltip("All players as a referenceable gameobject")]
	private GameObject player;
    #endregion

    #region PrivateVariables
    private bool inGame;
    private bool isPaused;
    #endregion

    #region Getters&Setters
    public GameObject Player { get { return player; } set { player = value; } }
	public bool InGame { get { return inGame; } set { inGame = value; } }
	public bool IsPaused { get { return isPaused; } set { isPaused = value; } }
    #endregion

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

	// Play game initial setups
	public void StartNewGame()
	{
		SpawnPlayersAtSpawnpoint();
        player.SetActive(true);
    }

	// Reset everything when game ends
	public void EndGame()
	{
		PauseGame(false);
		QuitToMainMenu();
    }

    public void PauseGame(bool enablePauseMenu)
    {
		if (!inGame) return;

		isPaused = !isPaused;
        if (enablePauseMenu)
            pauseMenu.SetActive(isPaused);

        if (isPaused)
			Time.timeScale = 0f;
		else
			Time.timeScale = 1f;
	}

	public void WinConditionMet(List<int> playerWinOrder) // TODO NATHANF: FILL OUT
	{
        // go to end screen
        // reset players
        //if (roundsAt >= 7) EndGame();
    }

    // Method to reset everything when quitting to main menu
    private void QuitToMainMenu()
	{
        PauseGame(false);
		inGame = false;
    }

	// Spawn players at appropiate spawn points
	private void SpawnPlayersAtSpawnpoint()
	{
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
		player.transform.position = new Vector3(-2, 7f, -7.5f);
        player.GetComponentInChildren<CapsuleCollider>().enabled = true;
        player.GetComponentInChildren<Rigidbody>().useGravity = true;
        player.SetActive(true);
    }
}
