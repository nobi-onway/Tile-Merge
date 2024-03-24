using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlGameStateButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameManager.GameState _state;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.State = _state;
    }
}
