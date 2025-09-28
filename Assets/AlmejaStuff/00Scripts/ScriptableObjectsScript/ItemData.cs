using UnityEditor;
using UnityEngine;

public enum InteractionType
{
    None,
    Collectable,
    Draggable,
    TriggerAction,
}

[CreateAssetMenu(fileName = "ItemData", menuName = "SrAlmejaSOs/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Datos básicos")]
    public string ItemName;
    [PreviewSprite]
    public Sprite ItemSprite;
    
    [HideInInspector] public bool IsCollectable;
    [HideInInspector] public bool IsDraggable;
    [HideInInspector] public bool TriggerAction;

    [Header("Extras")]
    public AudioClip InteractionSound;
    public string TooltipText;
    public string ItemID => $"{ItemName}_{ItemName.GetHashCode()}"; // ID generado automáticamente
    public InteractionType CurrentInteractionType;

    public void SetInteractionType(InteractionType type)
    {
        CurrentInteractionType = type;
        IsCollectable = type == InteractionType.Collectable;
        IsDraggable = type == InteractionType.Draggable;
        TriggerAction = type == InteractionType.TriggerAction;
    }
}