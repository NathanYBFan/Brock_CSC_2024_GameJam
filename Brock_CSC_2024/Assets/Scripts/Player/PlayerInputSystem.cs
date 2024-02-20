using NaughtyAttributes;
using Newtonsoft.Json;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    // Singleton Initialization
    public static PlayerInputSystem _Instance;

    #region Serialize Fields
    [SerializeField]
    [Foldout("Dependencies"), Tooltip("Script used to check for player interaction")]
    private PlayerLeftClick playerLeftClickScript;

    [SerializeField, ReadOnly]
    [Foldout("Stats"), Tooltip("Move direction")]
    private Vector3 move;
    #endregion
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a duplicated PlayerInputSystem Singleton");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            playerLeftClickScript.OnLeftClickDown();
        }

        if (Input.GetMouseButtonDown(1)) // Right  click
        {

        }

        if (Input.GetKeyDown(KeyCode.E)) // Interact
        {
            playerLeftClickScript.OnLeftClickDown();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager._Instance.InGame) return;
            GameManager._Instance.PauseGame(true);
        }
    }

    private void FixedUpdate()
    {
        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
    }

    public Vector3 GetMove() { return move; }
}
