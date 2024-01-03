using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileBehaviour : MonoBehaviour, IPointerDownHandler
{
    public event Action OnPointerDownHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownHandler?.Invoke();
    }
}
