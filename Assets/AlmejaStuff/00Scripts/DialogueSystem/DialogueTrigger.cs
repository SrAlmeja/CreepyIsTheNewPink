using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TextAsset inkJSON;

    public void TriggerDialogue()
    {
        dialogueManager.LoadStory(inkJSON);
    }
}