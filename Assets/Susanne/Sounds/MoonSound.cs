using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProximity : MonoBehaviour
{
    public Transform listener;  // Reference to the listener (e.g., player)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (listener != null && audioSource != null)
        {
            // Calculate the distance between the listener and the sound source
            float distance = Vector3.Distance(listener.position, transform.position);

            // Adjust the volume based on distance
            audioSource.volume = Mathf.Clamp01(1f - (distance - audioSource.minDistance) / (audioSource.maxDistance - audioSource.minDistance));
        }
    }
}

