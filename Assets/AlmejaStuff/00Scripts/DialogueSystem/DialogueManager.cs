using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;
    [Header("Conditional")]
    [SerializeField] private GameObject losePanel;
    
    [Header("InvokeAudios")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;
    
    [Header("Scene Flow")]
    [SerializeField] public UnityEvent onGameFinished;

    
    private Story story;

    private string lastCheckpoint = "start"; // Valor por defecto
    
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
        PlayerPrefs.DeleteKey("LastCheckpoint");
        PlayerPrefs.Save();

        if (inkJSON == null)
        {
            Debug.LogError("❌ inkJSON no está asignado.");
            return;
        }

        story = new Story(inkJSON.text);

        // Cargar checkpoint guardado si existe
        string savedCheckpoint = PlayerPrefs.GetString("LastCheckpoint", lastCheckpoint);
        story.ChoosePathString(savedCheckpoint);

        AdvanceStory();
    }

    public void AdvanceStory()
    {
        if (story == null || dialogueText == null) return;

        ClearChoices();

        if (story.canContinue)
        {
            string nextLine = story.Continue();
            dialogueText.text = nextLine;

            foreach (string tag in story.currentTags)
            {
                HandleTag(tag);
            }
        }
        else if (story.currentChoices.Count > 0)
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
        AdvanceStory();
    }
    void OnChoiceSelected(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        AdvanceStory();
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
        if (tag.StartsWith("checkpoint:"))
        {
            lastCheckpoint = tag.Substring("checkpoint:".Length);
            PlayerPrefs.SetString("LastCheckpoint", lastCheckpoint);
            PlayerPrefs.Save();
            Debug.Log($"📍 Checkpoint guardado: {lastCheckpoint}");
        }
        else if (tag == "death")
        {
            Debug.Log("💀 Muerte detectada. Mostrando panel de derrota.");
            losePanel.SetActive(true); // No reinicia automáticamente
        }
        else if (tag == "victory")
        {
            Debug.Log("🏆 Victoria detectada.");
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
    }

    public void TryAgain()
    {
        Debug.Log($"🔁 Reiniciando desde checkpoint: {lastCheckpoint}");
        story = new Story(inkJSON.text);
        story.ChoosePathString(lastCheckpoint);
        losePanel.SetActive(false);
        AdvanceStory();
    }

    void HandleDeath()
    {
        losePanel.SetActive(true);
    }


    void HandleVictory()
    {
        Debug.Log("🏆 El jugador ha ganado. Ejecutando evento de final.");
        onGameFinished?.Invoke();
    }


}

