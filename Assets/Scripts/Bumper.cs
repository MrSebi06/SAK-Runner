using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour 
{
    public float bumpForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        var rb = other.GetComponent<Rigidbody>();
        if (null == rb)
        {
            return;
        }
        
        rb.AddForce(Vector3.up * bumpForce, ForceMode.VelocityChange);
        
       
    }
}
