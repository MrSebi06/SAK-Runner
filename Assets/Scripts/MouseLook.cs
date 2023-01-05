<<<<<<< Updated upstream
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
=======
>>>>>>> Stashed changes
using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class MouseLook : MonoBehaviour
{
    public WallRun _wallRun;
    public float sensitivity = 100f;
    public Transform playerBody;
    
    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, _wallRun.tilt);
        // FOV();
        playerBody.Rotate(Vector3.up, mouseX);

    }
}
