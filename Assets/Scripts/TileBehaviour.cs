using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class TileBehaviour : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _iconSprite;

    public event Action OnPointerDownHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnPointerDownHandler?.Invoke();
    }

    private void EnableUIIf(bool enabled)
    {
        _iconSprite.enabled = enabled;
    }

    public void SetData(TileSetting settings)
    {
        EnableUIIf(true);

        _iconSprite.sprite = settings.Sprite;
        transform.DOScale(1.0f, 0.2f).SetEase(Ease.OutSine);
    }

    public async void ClearData()
    {
        await transform.DOScale(0.0f, 0.25f).SetEase(Ease.OutSine).AsyncWaitForCompletion();

        EnableUIIf(false);

        _iconSprite.sprite = null;
        transform.localScale = Vector3.zero;
    }
}
