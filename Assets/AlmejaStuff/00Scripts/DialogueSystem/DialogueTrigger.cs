using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private void OnEnable()
    {
        ItemsFunctionality.ItemOnActionEvent += OnItemTriggered;
    }

    private void OnDisable()
    {
        ItemsFunctionality.ItemOnActionEvent -= OnItemTriggered;
    }

    private void OnItemTriggered(ItemsFunctionality item)
    {
        // Aquí puedes validar si el item corresponde a este trigger, si lo deseas
        TriggerDialogue();
    }
    
    public void TriggerDialogue()
    {
        Debug.Log($"🗣️ Ejecutando diálogo:\n{inkJSON.text}");
        // Aquí puedes llamar a tu sistema de diálogo, por ejemplo:
        // DialogueManager.Instance.StartDialogue(inkJSON);
    }
}
