using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlide : MonoBehaviour
{
    // The player's movement script
    public PlayerMovement playerMovement;

    // The force to apply when sliding
    public float slideForce = 10f;

    // The maximum speed the player can slide at
    public float maxSlideSpeed = 5f;

    // The slope angle threshold for sliding faster
    public float slopeSlideThreshold = 45f;

    // The slope slide speed multiplier
    public float slopeSlideMultiplier = 2f;

    // A layer mask for the ground layer
    public LayerMask groundLayer;

    // The player's rigidbody
    private Rigidbody rb;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is pressing the left control key
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // Calculate the slide direction based on the player's current velocity and the ground normal
            Vector3 slideDirection = Vector3.ProjectOnPlane(rb.velocity, playerMovement.groundNormal);

            // Calculate the slide force based on the slope angle
            float slideMultiplier = 1f;
            if (Vector3.Angle(playerMovement.groundNormal, Vector3.up) > slopeSlideThreshold)
            {
                slideMultiplier = slopeSlideMultiplier;
            }

            // If the player is on the ground, apply the slide force
            if (IsOnGround())
            {
                rb.AddForce(slideDirection * slideForce * slideMultiplier, ForceMode.Acceleration);
            }
            // Otherwise, apply a reduced slide force
            else
            {
                rb.AddForce(slideDirection * slideForce * 0.5f * slideMultiplier, ForceMode.Acceleration);
            }

            // Clamp the player's velocity to the maximum slide speed
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSlideSpeed);
        }
    }

    // Check if the player is on the ground or on a slope
bool IsOnGround()
{
    // Cast a sphere downward from the center of the player's feet
    float sphereRadius = 0.4f;
    Vector3 sphereCenter = transform.position + Vector3.down * sphereRadius;
    Collider[] colliders = Physics.OverlapSphere(sphereCenter, sphereRadius, groundLayer);

    // If there are colliders within the sphere, check the slope angle
    if (colliders.Length > 0)
    {
        // Check the angle between the collider normal and the up vector
        float angle = Vector3.Angle(colliders[0].transform.up, Vector3.up);
        if (angle <= slopeSlideThreshold)
        {
            // The player is on the ground
            return true;
        }
        else
        {
            // The player is on a slope
            return true;
        }
    }
    return false;
}


}

