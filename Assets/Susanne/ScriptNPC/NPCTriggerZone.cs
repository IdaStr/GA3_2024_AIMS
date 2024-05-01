using UnityEngine;

public class TriggerCounter : MonoBehaviour
{
    public GameObject objectToAppear;
    private int triggerCount = 0;

    private void Start()
    {
      
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            triggerCount++;

         
            if (triggerCount >= 3 && objectToAppear != null)
            {
                objectToAppear.SetActive(true);
            }
        }
    }
}

