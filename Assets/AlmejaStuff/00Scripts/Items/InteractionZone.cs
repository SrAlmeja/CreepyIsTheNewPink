using UnityEngine;
using UnityEngine.Events;


public class InteractionZone : MonoBehaviour
{
    [Header("Item requerido")]
    [SerializeField] private ItemData requiredItem;
    
    [Header("Eventos")]
    public UnityEvent OnZoneActivated;


    public bool ValidateItem(ItemData incomingItem)
    {
        return incomingItem != null && incomingItem.ItemID == requiredItem.ItemID;
    }

    public void ActivateZone()
    {
        Debug.Log($"✅ Zona activada por: {requiredItem.ItemName}");
        OnZoneActivated?.Invoke();

    }
}

