using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "SrAlmejaSOs/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Datos básicos")]
    public string ItemName;
    [PreviewSprite]
    public Sprite ItemSprite;

    [Header("Interacción")]
    public bool IsCollectible;
    public bool IsDraggable;
    public bool TriggersAction;

    [Header("Extras")]
    public AudioClip InteractionSound;
    public string TooltipText;

    // ID generado automáticamente
    public string ItemID => $"{ItemName}_{ItemName.GetHashCode()}";
}