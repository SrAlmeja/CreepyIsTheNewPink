using System;
using UnityEngine;
using DG.Tweening;
public class ItemsFunctionality : MonoBehaviour
{
    #region Variables
    
    [Header("AnimationStuff")]
    [SerializeField] private float scaleTo;
    public static event Action<ItemsFunctionality> ItemOnActionEvent;
    
    private Vector3 _screanCenter, _wolrdCenter;
    private Sequence _collectSequence;
    #endregion

    public void Collect()
    {
        _screanCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        _wolrdCenter = Camera.main.ScreenToWorldPoint(_screanCenter);
        _wolrdCenter.z = transform.position.z;
        
        _collectSequence = DOTween.Sequence();
        
        _collectSequence.Append(transform.DOMove(_wolrdCenter, 0.5f).SetEase(Ease.OutQuad));
        _collectSequence.Join(transform.DOScale(scaleTo, 0.5f).SetEase(Ease.OutQuad));
        _collectSequence.AppendInterval(1f);
        _collectSequence.OnComplete(() =>
        {
            Debug.Log($"📦 Recogido y ocultado: {gameObject.name}");
            gameObject.SetActive(false);
        });
    }
    
    public void Draggable()
    {
        Debug.Log($"🖐️ Arrastrando: {gameObject.name}");
    }
    
    public void TriggerAction()
    {
        ItemOnActionEvent?.Invoke(this);
    }

    
}
