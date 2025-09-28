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
    
    private bool _isDragging;
    private Vector3 _originalPos;
    #endregion

    private void Update()
    {
        if (_isDragging && Input.GetMouseButton(0))
        {
            DragMe();
        }

        if (_isDragging && Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            transform.position = _originalPos;
        }
    }
    
    #region PublicMethods
    public void Collect()
    {
        AnimateMe();
    }
    public void Draggable()
    {
        _originalPos = transform.position;
        _isDragging = true;
        Debug.Log($"🖐️ Arrastrando: {gameObject.name}");
    }
    public void TriggerAction()
    {
        ItemOnActionEvent?.Invoke(this);
    }
    #endregion
    
    private void AnimateMe()
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
    private void DragMe()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        gameObject.transform.position = mouseWorldPos;

    }
    
}
