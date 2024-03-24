using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlGamePlayStateButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GamePlayController.GamePlayState _state;

    public void OnPointerDown(PointerEventData eventData)
    {
        GamePlayController.Instance.CurrentState = _state;
    }
}
