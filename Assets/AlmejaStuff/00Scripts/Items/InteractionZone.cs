using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    [Header("Item requerido")]
    [SerializeField] private ItemData requiredItem;

    public bool ValidateItem(ItemData incomingItem)
    {
        return incomingItem != null && incomingItem.ItemID == requiredItem.ItemID;
    }

    public void ActivateZone()
    {
        Debug.Log($"✅ Zona activada por: {requiredItem.ItemName}");
        // Aquí puedes disparar efectos, diálogos, misiones, etc.
    }
}

