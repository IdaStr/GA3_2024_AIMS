using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FootstepManager))] // Ensure FootstepManager component is present on the same GameObject
public class PlayerFootstepDetector : MonoBehaviour
{
    private FootstepManager footstepManager;
    private bool isInsideCollider = false;

    void Start()
    {
        // Get the FootstepManager component from the same GameObject
        footstepManager = GetComponent<FootstepManager>();
        if (footstepManager == null)
        {
            Debug.LogError("FootstepManager component not found on Player GameObject.");
        }
    }

    void Update()
    {
        // Detect player movement and trigger footstep sounds inside collider
        if (isInsideCollider && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            footstepManager.StartFootsteps();
            footstepManager.TriggerFootsteps();
        }
        else
        {
            footstepManager.StopFootsteps();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the collider
        if (other.CompareTag("FootstepCollider"))
        {
            isInsideCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player exits the collider
        if (other.CompareTag("FootstepCollider"))
        {
            isInsideCollider = false;
            footstepManager.StopFootsteps(); // Stop footstep sounds if player exits collider
        }
    }
}
