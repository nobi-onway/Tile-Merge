using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public enum GamePlayState
    {
        init,
        playing,
        win,
        lose,
    }

    private static GamePlayController _instance;
    public static GamePlayController Instance => _instance;

    [SerializeField]
    private TileBoardBehaviour _tileBoardBehaviour;
    [SerializeField]
    private TileMergeBarBehaviour _tileMergeBarBehavior;

    private GamePlayState _currentState;
    public GamePlayState CurrentState
    {
        get => _currentState;
        set
        {
            _currentState = value;
            OnStateChange?.Invoke(value);
        }
    }

    public event Action<GamePlayState> OnStateChange;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    private void Start()
    {
        OnStateChange += (state) =>
        {
            if (state == GamePlayState.init) Init();
            if (state == GamePlayState.playing) StartGame();
            if (state == GamePlayState.win) OnWin();
        };

        CurrentState = GamePlayState.init;
    }

    private void Init()
    {
        _tileBoardBehaviour.OnSelectedTile += AddToTileBar;

        CurrentState = GamePlayState.playing;
    }

    private void OnWin()
    {
        LevelController.Instance.LevelUp();
    }

    private void StartGame()
    {
        _tileBoardBehaviour.GenerateBoard();
        _tileMergeBarBehavior.GenerateTileMergeBar();
    }

    private void AddToTileBar(TileSetting settings) => _tileMergeBarBehavior.AddToTileList(settings);
}
