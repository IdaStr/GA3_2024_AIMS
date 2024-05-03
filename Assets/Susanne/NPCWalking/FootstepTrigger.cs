using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public float volume = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FootstepManager footstepManager = other.GetComponent<FootstepManager>();
            if (footstepManager != null)
            {
                footstepManager.SetVolume(volume); 
                footstepManager.footstepSounds = footstepSounds;
            }
        }
    }
}

