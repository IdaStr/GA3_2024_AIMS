using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{
    public AudioClip[] footstepSounds; 

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            
            FootstepManager footstepManager = other.GetComponent<FootstepManager>();
            if (footstepManager != null)
            {
               
                footstepManager.footstepSounds = footstepSounds;
            }
        }
    }
}
