using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        lobby,
        gameplay
    }

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private GameState _state;
    public GameState State
    {
        get { return _state; }
        set { _state = value; OnStateChangeHandler?.Invoke(value); }
    }

    private event Action<GameState> OnStateChangeHandler;

    private readonly Dictionary<GameState, string> sceneNameMap = new Dictionary<GameState, string>
    {
        { GameState.lobby, "LobbyScene" },
        { GameState.gameplay, "GameScene" }
    };

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        OnStateChangeHandler += state =>
        {
            SceneManager.LoadScene(sceneNameMap[state]);
        };
    }

}
