using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionButton; // UI element for interaction button
    public GameObject interactionText;   // UI element for interaction text
    public string npcName = "NPC";       // Name of the NPC
    public List<Dialogue> dialogues;     // List of dialogues to display with associated audio clips

    private bool playerInRange;          // Flag to track if player is in range
    private int currentDialogueIndex;    // Index of the current dialogue
    private bool hasInteracted;          // Flag to track if interaction has occurred

    private AudioSource audioSource;     // Audio source component for playing dialogue audio

    private void Start()


    {
        
            audioSource = gameObject.AddComponent<AudioSource>();
        
        // Ensure interaction button and text are initially hidden
        interactionButton.SetActive(false);
        interactionText.SetActive(false);
        currentDialogueIndex = 0; // Start at the beginning of the dialogues list

        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (!hasInteracted)
            {
                interactionButton.SetActive(true); // Show interaction button
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            interactionButton.SetActive(false); // Hide interaction button
        }
    }

    private void Update()
    {
        // Check for interaction key (e.g., E) press
        if (playerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            Interact(); // Trigger interaction if player is in range and presses E
        }
    }

    public void Interact()
    {
        if (playerInRange && !hasInteracted && currentDialogueIndex < dialogues.Count)
        {
            // Hide interaction button
            interactionButton.SetActive(false);

            // Show interaction text with NPC name and current dialogue
            interactionText.SetActive(true);
            string dialogueText = $"{npcName}: {dialogues[currentDialogueIndex].text}";
            interactionText.GetComponentInChildren<TextMeshProUGUI>().text = dialogueText;

            // Play interaction audio for the current dialogue
            if (audioSource != null && dialogues[currentDialogueIndex].audioClip != null)
            {
                audioSource.clip = dialogues[currentDialogueIndex].audioClip;
                audioSource.Play();
            }

            // Move to the next dialogue
            currentDialogueIndex++;

            // If all dialogues have been displayed, mark interaction as complete
            if (currentDialogueIndex >= dialogues.Count)
            {
                hasInteracted = true;
            }
        }
    }
}

[System.Serializable]
public class Dialogue
{
    public string text;       // Text to display for this dialogue
    public AudioClip audioClip; // Audio clip to play for this dialogue
}
