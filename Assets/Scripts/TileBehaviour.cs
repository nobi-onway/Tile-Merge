using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class TileBehaviour : MonoBehaviour, IPointerDownHandler
{
    private const float ANIMATION_END_VALUE = 1.0f;
    private const float ANIMATION_DURATION = 0.2f;

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
        transform.DOScale(ANIMATION_END_VALUE, ANIMATION_DURATION).SetEase(Ease.OutSine);
    }

    public void ClearData()
    {
        EnableUIIf(false);

        _iconSprite.sprite = null;
        transform.localScale = Vector3.zero;
    }
}
