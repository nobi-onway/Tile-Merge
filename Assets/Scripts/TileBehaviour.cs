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

    private bool _enabled;
    public bool Enabled 
    {  
        get { return _enabled; }
        set 
        { 
            _enabled = value; 
            
            _iconSprite.color = value ? Color.white : new Color(1,1,1,0.4f) ; 
        }
    } 

    public event Action OnPointerDownHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_enabled) return;
        OnPointerDownHandler?.Invoke();
    }

    private void EnableUIIf(bool enabled)
    {
        _iconSprite.enabled = enabled;
    }

    public void SetData(TileSetting settings)
    {
        EnableUIIf(true);
        Enabled = true;

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
