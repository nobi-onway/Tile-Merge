using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TileBehaviour : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _iconSprite;
    [SerializeField]
    private Image _backgroundSprite;

    public event Action OnPointerDownHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownHandler?.Invoke();
    }

    private void EnableUIIf(bool enabled)
    {
        _iconSprite.enabled = enabled;
        _backgroundSprite.enabled = enabled;
    }

    public void SetData(TileSetting settings)
    {
        EnableUIIf(true);



        _iconSprite.sprite = settings.Sprite;
    }

    public void ClearData()
    {
        EnableUIIf(false);

        _iconSprite.sprite = null;
    }
}
