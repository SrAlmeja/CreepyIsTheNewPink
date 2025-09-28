using UnityEngine;

public class EventTester : MonoBehaviour
{
    private void OnEnable()
    {
        ItemsFunctionality.ItemOnActionEvent += HandleAction;
    }

    private void OnDisable()
    {
        ItemsFunctionality.ItemOnActionEvent -= HandleAction;
    }
    
    private void HandleAction(ItemsFunctionality source)
    {
        Debug.Log($"Un objeto me activó: {source.gameObject.name}");
    }
}