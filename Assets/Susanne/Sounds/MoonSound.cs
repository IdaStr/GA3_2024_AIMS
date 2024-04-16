using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundProximity : MonoBehaviour
{
    public Transform listener; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (listener != null && audioSource != null)
        {
            
            float distance = Vector3.Distance(listener.position, transform.position);

            
            audioSource.volume = Mathf.Clamp01(1f - (distance - audioSource.minDistance) / (audioSource.maxDistance - audioSource.minDistance));
        }
    }
}

