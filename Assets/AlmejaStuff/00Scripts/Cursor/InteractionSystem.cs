using System;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private CursorController cursor;
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            
        if (hit.collider != null)
        {
            Debug.Log($"raycast hit: {hit.collider.name}");
            cursor.SetInteractionCursor();
        }
        else
        {
            Debug.Log("Nada detectado");
            cursor.SetDefaultCursor();
        }
        
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            if (hit.collider != null)
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    Debug.Log($"🎯 Interacción con: {hit.collider.gameObject.name}");
                }
                else
                {
                    Debug.Log($"👀 Golpeó pero no es interactuable: {hit.collider.gameObject.name}");
                }
            }
            else
            {
                Debug.Log("🚫 Clic sin colisión");
            }
        }
    }
}

