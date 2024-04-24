using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Footstep sounds to play
    [Range(0.1f, 1.0f)]
    public float footstepInterval = 0.5f; // Interval between footstep sounds in seconds (adjustable in Inspector)

    private AudioSource audioSource;
    private bool isPlayingFootsteps = false;
    private float footstepTimer = 0f;

    void Start()
    {
        // Create an AudioSource component dynamically
        audioSource = gameObject.AddComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("Failed to add AudioSource component. FootstepManager cannot play footstep sounds.");
            enabled = false; // Disable the script if AudioSource creation failed
        }

        // Configure AudioSource settings for footstep sound
        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Update footstep timer
        footstepTimer += Time.deltaTime;
    }

    public void PlayFootstepSound()
    {
        if (footstepSounds != null && footstepSounds.Length > 0)
        {
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];

            if (footstepSound != null)
            {
                audioSource.clip = footstepSound;
                audioSource.Play();
            }
        }
    }

    public void StartFootsteps()
    {
        if (!isPlayingFootsteps)
        {
            isPlayingFootsteps = true;
        }
    }

    public void StopFootsteps()
    {
        if (isPlayingFootsteps)
        {
            isPlayingFootsteps = false;
        }
    }

    public void TriggerFootsteps()
    {
        if (isPlayingFootsteps && footstepTimer >= footstepInterval)
        {
            PlayFootstepSound();
            footstepTimer = 0f; // Reset footstep timer
        }
    }
}
