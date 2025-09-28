using System;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable

{
    #region Variables
    [Header("Object")]
    public ItemData ItemData;
    [SerializeField] private SpriteRenderer itemImage;
    [SerializeField] private ItemsFunctionality itemsFunctionality;
    
    #endregion

    private void Awake()
    {
        itemImage.sprite = ItemData.ItemSprite;
        
        if (itemsFunctionality == null)
        {
            Debug.LogError("ItemsFunctionality is null");
        }
        else
        {
            itemsFunctionality.ItemData = ItemData;
        }
    }

    public void Interact()
    {
        if (ItemData == null) return;

        if (ItemData.InteractionSound)
            AudioSource.PlayClipAtPoint(ItemData.InteractionSound, transform.position);

        if (ItemData.IsCollectable)
        {
            itemsFunctionality.Collect();
        }
            
        if (ItemData.IsDraggable)
        {
            itemsFunctionality.Draggable();
        }

        if (ItemData.TriggerAction)
        {
            itemsFunctionality.TriggerAction();
        }
           
    }
    public string GetTooltip() => ItemData.TooltipText;
    public Sprite GetIcon() => ItemData.ItemSprite;
}
