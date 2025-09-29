using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueManager : PersistentSingleton<DialogueManager>
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    [Header("UI")]
    [SerializeField] private Text dialogueText;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;

    private Story story;

    void Start()
    {
        story = new Story(inkJSON.text);
        RefreshView();
    }

    void RefreshView()
    {
        ClearChoices();

        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }

        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                Button button = Instantiate(choiceButtonPrefab, choicesContainer);
                button.GetComponentInChildren<Text>().text = choice.text;
                button.onClick.AddListener(() => OnChoiceSelected(choice));
            }
        }
    }

    void OnChoiceSelected(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void ClearChoices()
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }
    }
}

