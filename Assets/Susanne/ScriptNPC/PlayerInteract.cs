using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer; // Layer mask for interaction raycast

    private void Update()
    {
        // Check for interaction key (E) press
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Raycast to detect interactable objects
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, interactLayer))
            {
                // Check if the hit object has NPCInteraction component
                NPCInteraction npcInteraction = hit.collider.GetComponent<NPCInteraction>();
                if (npcInteraction != null)
                {
                    // Trigger NPC interaction
                    npcInteraction.Interact();
                }
            }
        }
    }
}
