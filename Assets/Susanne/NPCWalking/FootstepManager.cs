using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    [Range(0.1f, 1.0f)]
    public float footstepInterval = 0.5f;

    private AudioSource audioSource;
    private bool isPlayingFootsteps = false;
    private float footstepTimer = 0f;
    private float volume = 1.0f;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("Hello Susanne, Audio ain't playing!");
            enabled = false;
        }

        audioSource.loop = false;
        audioSource.playOnAwake = false;
    }

    void Update()
    {
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
                audioSource.volume = volume; 
                audioSource.Play();
            }
        }
    }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
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
            footstepTimer = 0f;
        }
    }
}
