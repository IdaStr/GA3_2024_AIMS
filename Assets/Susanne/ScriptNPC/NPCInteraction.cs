using System.Collections;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionButton; // UI element for interaction button
    public GameObject interactionText;   // UI element for interaction text
    public string npcName = "NPC";       // Name of the NPC
    public string dialogueText;          // Text to display when interacting
    public AudioClip interactionAudio;   // Audio clip to play when interacting

    private bool isPlayerInRange;        // Flag to track if player is in range for interaction
    private bool hasInteracted;          // Flag to track if interaction has occurred
    private AudioSource audioSource;     // Reference to AudioSource component

    private void Start()
    {
        interactionButton.SetActive(false); // Ensure interaction button is initially hidden
        interactionText.SetActive(false);   // Ensure interaction text is initially hidden

        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = interactionAudio;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;

            // Show interaction button only if player is in range and interaction has not occurred
            if (!hasInteracted)
            {
                interactionButton.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            // Hide interaction button when player exits NPC range
            interactionButton.SetActive(false);
        }
    }

    public void Interact()
    {
        if (isPlayerInRange && !hasInteracted)
        {
            // Hide interaction button
            interactionButton.SetActive(false);

            // Show interaction text with NPC name and dialogue
            interactionText.SetActive(true);
            TMPro.TextMeshProUGUI textMesh = interactionText.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            if (textMesh != null)
            {
                textMesh.text = npcName + ": " + dialogueText;
            }

            // Play interaction audio
            if (interactionAudio != null && audioSource != null)
            {
                audioSource.PlayOneShot(interactionAudio);
                Invoke("EndInteraction", interactionAudio.length); // Automatically end interaction after audio length
                hasInteracted = true; // Set interaction flag to true
            }
        }
    }

    private void EndInteraction()
    {
        // Hide interaction text
        interactionText.SetActive(false);
        // Reset interaction state
        hasInteracted = false;
    }
}
