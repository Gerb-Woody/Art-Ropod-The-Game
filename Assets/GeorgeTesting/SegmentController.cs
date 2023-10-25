using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour
{
    public float stepHeight = 0.5f; // The maximum height of a step.
    public LayerMask stairLayer;

    private bool isClimbing = false;

    private void FixedUpdate()
    {
        // Check for walls in front.
        if (Physics.Raycast(transform.position, transform.forward, 1.0f))
        {
            // If there's a wall face in front, start climbing.
            isClimbing = true;
        }

        // Check for stairs below the segment.
        if (!Physics.Raycast(transform.position, Vector3.down, stepHeight + 0.1f, stairLayer))
        {
            // If a stair isnt detected under the segment, it's no longer climbing stairs
            isClimbing = true;
        }


        if (isClimbing)
        {
            // Rotate the segment upward (lift the front of the segment).
            // You can adjust the rotation speed for the desired effect.
            transform.Rotate(Vector3.up * 90.0f * Time.fixedDeltaTime);
        }
        else
        {
            // If not climbing, reset the segment's rotation to its normal position.
            transform.localRotation = Quaternion.identity;
        }
    }
}
