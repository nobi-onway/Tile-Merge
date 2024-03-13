using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Transform _losePanel;
    [SerializeField]
    private Transform _winPanel;

    private void Start()
    {
        GamePlayController.Instance.OnStateChange += (state) =>
        {
            ShowIf(_losePanel, state == GamePlayController.GamePlayState.lose);
            ShowIf(_winPanel, state == GamePlayController.GamePlayState.win);
        };
    }

    private void ShowIf(Transform transform, bool canShow)
    {
        transform.gameObject.SetActive(canShow);
    }
}
