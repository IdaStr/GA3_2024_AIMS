using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer; 

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, interactLayer))
            {
                
                NPCInteraction npcInteraction = hit.collider.GetComponent<NPCInteraction>();
                if (npcInteraction != null)
                {
                    
                    npcInteraction.Interact();
                }
            }
        }
    }
}
