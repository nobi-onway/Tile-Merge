using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private Button _nextLevelButton;

    private void Start()
    {
        _nextLevelButton.onClick.AddListener(() => GamePlayController.Instance.CurrentState = GamePlayController.GamePlayState.playing);
    }
}
