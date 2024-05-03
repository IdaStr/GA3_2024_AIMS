using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    public float radius = 2f;      
    public float speed = 1f;       

    private Vector3 centerPosition;
    private Vector3 lastPosition;

    void Start()
    {
        
        if (transform != null)
        {
            
            centerPosition = transform.position;
            lastPosition = transform.position;
        }
        else
        {
            Debug.LogError("Is the transform working? I set it to null");
        }
    }

    void Update()
    {
        
        float angle = Time.time * speed;    
        float x = centerPosition.x + radius * Mathf.Cos(angle);  
        float z = centerPosition.z + radius * Mathf.Sin(angle);  

        Vector3 newPosition = new Vector3(x, centerPosition.y, z);

        
        if (transform != null)
        {
            transform.position = newPosition;

           
            Vector3 moveDirection = newPosition - lastPosition;
            moveDirection.y = 0f;   

           
            if (moveDirection != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = newRotation;
            }

            
            lastPosition = newPosition;
        }
    }
}


