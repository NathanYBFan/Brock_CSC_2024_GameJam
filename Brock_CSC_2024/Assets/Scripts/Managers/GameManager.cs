using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Initialization
    public static GameManager _Instance;

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Debug.LogWarning("Destroyed a duplicated GameManager Singleton");
            Destroy(this.gameObject);
        }
        else if (_Instance == null)
            _Instance = this;
    }
}
