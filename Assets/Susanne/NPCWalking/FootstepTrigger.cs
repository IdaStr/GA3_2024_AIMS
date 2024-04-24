using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Footstep sounds for this trigger

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider is the player
        if (other.CompareTag("Player"))
        {
            // Get the FootstepManager component from the player GameObject
            FootstepManager footstepManager = other.GetComponent<FootstepManager>();
            if (footstepManager != null)
            {
                // Set the footstep sounds in the FootstepManager
                footstepManager.footstepSounds = footstepSounds;
            }
        }
    }
}
