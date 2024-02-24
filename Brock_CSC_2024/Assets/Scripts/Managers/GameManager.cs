using NaughtyAttributes;
using System.Collections;
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

	[SerializeField]
	private float roundTimer = 60; // In seconds
	[SerializeField, ReadOnly]
	private float timer = 0f;

	[SerializeField]
	private GameObject UI;
    #endregion

    #region PrivateVariables
    private bool inGame = false;
	private bool isPaused;
	#endregion

	#region Getters&Setters
	public GameObject Player { get { return player; } set { player = value; } }
	public bool InGame { get { return inGame; } set { inGame = value; } }
	public bool IsPaused { get { return isPaused; } set { isPaused = value; } }
	public float RoundTimer { get { return roundTimer; } }
	public float Timer { get { return timer; } }
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

		inGame = false;
	}

	// Play game initial setups
	public void StartNewGame()
	{
		UI.SetActive(true);
		SpawnPlayersAtSpawnpoint();
        player.SetActive(true);
		inGame = true;
		StartCoroutine(StartTimer());
    }

	// Reset everything when game ends
	public void EndGame()
	{
		UI.SetActive(false);
        PauseGame(false);
		// Calculate score
		// Win/Lose screen
		inGame = false;
		QuitToMainMenu(); // Debug only, delete this later
    }

    public void PauseGame(bool enablePauseMenu)
    {
		if (!inGame) return;

		isPaused = enablePauseMenu;
        pauseMenu.SetActive(enablePauseMenu);

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
		LevelLoadManager._Instance.StartLoadNewLevel(LevelLoadManager._Instance.LevelNamesList[3]);
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

	private IEnumerator StartTimer()
	{
		timer = roundTimer;
		while (timer > 0)
		{
			timer -= Time.deltaTime;
			yield return null;
		}
		timer = 0;
		EndGame();
	}
}
