using System;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ItemsFunctionality : MonoBehaviour
{
    #region Variables
    public ItemData ItemData { get; set;}
    
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
            DropMeHere();
        }
    }
    
    #region PublicMethods
    public void Collect()
    {
        AnimateMe();
        ItemOnActionEvent?.Invoke(this);
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
    
    #region PrivateMethods
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
    private void DropMeHere()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        if (myCollider != null) myCollider.enabled = false;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        
        if (hit.collider != null)
        {
            string tag = hit.collider.tag;

            InteractionZone zone = hit.collider.GetComponent<InteractionZone>();
            if (zone != null && zone.ValidateItem(ItemData))
            {
                zone.ActivateZone();
                Debug.Log($"🎯 Item válido: {ItemData.ItemName}");
                AnimateMe();
            }
            else if (tag == "Inventory")
            {
                transform.SetParent(hit.collider.transform);
                transform.position = hit.collider.bounds.center;
                Debug.Log($"📦 Drop en inventario: {hit.collider.name}");
            }
            else
            {
                Debug.Log($"🚫 Drop en zona no válida: {hit.collider.name}");
                transform.position = _originalPos;
            }
        }
        else
        {
            Debug.Log("🚫 No se detectó ninguna zona al soltar");
            transform.position = _originalPos;
        }
        if (myCollider != null) myCollider.enabled = true;
    }
    #endregion
    
    
    
}
