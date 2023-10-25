using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentipedeController : MonoBehaviour
{
    private float stepDistance = 0.25f; // Set the desired step distance.
    
    private Vector3 currentPosition;

    void Start()
    {
        currentPosition = transform.position;
    }

    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.R) ||
                Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.F))
            {
                // Calculate the next position based on the current position and step distance.
                Vector3 nextPosition = currentPosition + transform.forward * stepDistance;

                // Move the centipede.
                transform.position = nextPosition;

                // Update the current position.
                currentPosition = nextPosition;

                
            }
        
    }
}

