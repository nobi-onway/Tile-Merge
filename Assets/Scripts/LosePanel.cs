using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField]
    private Button _rematchButton;
    [SerializeField]
    private Button _homeButton;

    private void Start()
    {
        _rematchButton.onClick.AddListener(() => GamePlayController.Instance.CurrentState = GamePlayController.GamePlayState.playing);
    }
}
