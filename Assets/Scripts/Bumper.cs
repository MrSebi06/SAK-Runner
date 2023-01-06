using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumpForce = 10f;
    public PlayerMovement pm;
    
    //Make the player jump in the air when he is on a bumper
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var rb = other.GetComponent<Rigidbody>();
            if (null == rb) return;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.AddForce(Vector3.up * bumpForce * pm.runSpeed, ForceMode.VelocityChange);
            }
            else
            {
                rb.AddForce(Vector3.up * bumpForce, ForceMode.VelocityChange);
            }

        }
    }
}
