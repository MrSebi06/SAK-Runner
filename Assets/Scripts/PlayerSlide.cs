using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    // The threshold angle for determining whether the player is on a slope
    public float slopeLimit = 45f;

    // The player's current velocity
    private Vector3 velocity;

    // The player's current movement direction
    private Vector3 direction;

    // A reference to the player's Rigidbody component
    private Rigidbody rb;

    void Start()
    {
        // Get the player's Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get the player's current velocity and direction
        velocity = rb.velocity;
        direction = velocity.normalized;

        // Check if the player is on a slope
        if (IsOnSlope())
        {
            // If the player is on a slope, apply a sliding force
            ApplySlidingForce();
        }
    }

    // Returns true if the player is on a slope, false otherwise
    bool IsOnSlope()
    {
        // Cast a ray downward from the player's position
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // If the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Get the slope angle
            float angle = Vector3.Angle(hit.normal, transform.up);

            // Return true if the slope angle is greater than the threshold
            return angle > slopeLimit;
        }

        return false;
    }

    // Applies a sliding force to the player
    void ApplySlidingForce()
    {
        // Calculate the sliding force
        Vector3 slide = new Vector3(direction.x, -1f, direction.z);
        slide *= rb.mass;

        // Apply the sliding force to the player
        rb.AddForce(slide, ForceMode.Impulse);
    }
}