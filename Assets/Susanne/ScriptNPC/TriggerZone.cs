using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public AudioClip triggerSound;
    public string message = "YOH";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
       
            AudioSource.PlayClipAtPoint(triggerSound, transform.position);

       
            Debug.Log(message);


            hasTriggered = true;
        }
    }
}
