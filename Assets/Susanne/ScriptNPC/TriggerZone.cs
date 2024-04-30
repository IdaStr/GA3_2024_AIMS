using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public AudioClip triggerSound;
    public string message = "You entered the trigger zone.";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            // Play the trigger sound
            AudioSource.PlayClipAtPoint(triggerSound, transform.position);

            // Display the message
            Debug.Log(message);

            // Set hasTriggered to true to prevent multiple triggers
            hasTriggered = true;
        }
    }
}
