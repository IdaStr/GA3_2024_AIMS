using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactionButton; 
    public GameObject interactionText;   
    public string npcName = "NPC";       
    public List<Dialogue> dialogues;     

    private bool playerInRange;          
    private int currentDialogueIndex;    
    private bool hasInteracted;          

    private AudioSource audioSource;     

    private void Start()


    {
        
            audioSource = gameObject.AddComponent<AudioSource>();
        
        
        interactionButton.SetActive(false);
        interactionText.SetActive(false);
        currentDialogueIndex = 0; 

        
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
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
            playerInRange = false;
            interactionButton.SetActive(false); 
        }
    }

    private void Update()
    {
        
        if (playerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            Interact(); 
        }
    }

    public void Interact()
    {
        if (playerInRange && !hasInteracted && currentDialogueIndex < dialogues.Count)
        {
            
            interactionButton.SetActive(false);

            
            interactionText.SetActive(true);
            string dialogueText = $"{npcName}: {dialogues[currentDialogueIndex].text}";
            interactionText.GetComponentInChildren<TextMeshProUGUI>().text = dialogueText;

            
            if (audioSource != null && dialogues[currentDialogueIndex].audioClip != null)
            {
                audioSource.clip = dialogues[currentDialogueIndex].audioClip;
                audioSource.Play();
            }

            
            currentDialogueIndex++;

           
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
    public string text;       
    public AudioClip audioClip; 
}
