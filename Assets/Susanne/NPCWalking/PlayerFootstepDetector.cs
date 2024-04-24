using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FootstepManager))] 
public class PlayerFootstepDetector : MonoBehaviour
{
    private FootstepManager footstepManager;
    private bool isInsideCollider = false;

    void Start()
    {
      
        footstepManager = GetComponent<FootstepManager>();
        if (footstepManager == null)
        {
            Debug.LogError("FootstepManager component not found on Player GameObject.");
        }
    }

    void Update()
    {
       
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
        
        if (other.CompareTag("FootstepCollider"))
        {
            isInsideCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("FootstepCollider"))
        {
            isInsideCollider = false;
            footstepManager.StopFootsteps(); 
        }
    }
}
