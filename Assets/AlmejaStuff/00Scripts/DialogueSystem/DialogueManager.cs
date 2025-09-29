using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;
    
    [Header("InvokeAudios")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;
    
    private Story story;

    void OnEnable()
    {
        GameEvents.OnPlayerDeath += HandleDeath;
        GameEvents.OnPlayerVictory += HandleVictory;
    }

    void OnDisable()
    {
        GameEvents.OnPlayerDeath -= HandleDeath;
        GameEvents.OnPlayerVictory -= HandleVictory;
    }

    
    void Start()
    {
        if (inkJSON == null)
        {
            Debug.LogError("❌ inkJSON no está asignado.");
            return;
        }

        story = new Story(inkJSON.text);
        RefreshView();
    }

    void RefreshView()
    {
        if (dialogueText == null || story == null) return;

        ClearChoices();

        string fullText = "";

        while (story.canContinue)
        {
            fullText += story.Continue();
            fullText += "\n"; // Opcional: separador entre líneas
        }

        dialogueText.text = fullText;

        foreach (string tag in story.currentTags)
        {
            HandleTag(tag); // Si usas tags como #victory o #play:audio
        }

        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                Button button = Instantiate(choiceButtonPrefab, choicesContainer);
                button.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;
                button.onClick.AddListener(() => OnChoiceSelected(choice));
            }
        }
    }

    public void LoadStory(TextAsset newInkJSON)
    {
        inkJSON = newInkJSON;
        story = new Story(inkJSON.text);
        RefreshView();
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
    
    void HandleTag(string tag)
    {
        if (tag == "death")
        {
            Debug.Log("💀 Muerte detectada desde Ink");
            GameEvents.TriggerDeath();
        }
        else if (tag == "victory")
        {
            Debug.Log("🏆 Victoria detectada desde Ink");
            GameEvents.TriggerVictory();
        }
        else if (tag.StartsWith("play:"))
        {
            string clipName = tag.Substring(5);
            AudioClip clip = audioClips.Find(c => c.name == clipName);
            if (clip != null)
            {
                audioSource.PlayOneShot(clip);
                Debug.Log($"🔊 Reproduciendo audio: {clipName}");
            }
            else
            {
                Debug.LogWarning($"⚠️ Clip no encontrado: {clipName}");
            }
        }
        else
        {
            Debug.Log($"📎 Tag desconocido: {tag}");
        }
    }
    
    void HandleDeath()
    {
        Debug.Log("💀 El jugador ha muerto. Mostrar pantalla de derrota.");
        // Aquí puedes cargar escena, mostrar UI, etc.
    }

    void HandleVictory()
    {
        Debug.Log("🏆 El jugador ha ganado. Mostrar pantalla de victoria.");
        // Aquí puedes guardar progreso, cambiar escena, etc.
    }


}

