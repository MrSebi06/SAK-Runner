using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerBody;

    [Header("Movement")] 
    public float moveSpeed;
    public float groundDrag;
    private Vector3 _playerMovementInput;

    [Header("Jumping")] 
    public float jumpForce;
    public float airMultiplier;
    private bool _readyToJump;
    
    [Header("WallRun")]
    private float Wallrun_Speed;
    public enum MovementState
    {
        Wallrunning,
    } 
    public MovementState state;
    public bool wallrunning;
    public bool walking;
    public bool jumping;


    [Header("Ground Check")] 
    public float playerHeight;
    public LayerMask groundLayer;
    public bool _isGrounded;

    private void Update()
    {
        // Input
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.Space) && _isGrounded && !_readyToJump)
        {
            _readyToJump = true;
        }
    }

    private void FixedUpdate()
    {
        // Ground check
        // _isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);
        _isGrounded = Physics.CheckBox(new Vector3(transform.position.x, transform.position.y - playerHeight/2, transform.position.z), new Vector3(0.45f, 0.1f, 0.45f), transform.rotation, groundLayer);

        if (wallrunning)
        {
            state = MovementState.Wallrunning;
            // moveSpeed = Wallrun_Speed;
        }
        if (_isGrounded )
        {
            playerBody.drag = groundDrag;
        }
        else
        {
            playerBody.drag = 0;
        }
        
        MovePlayer();

        if (_readyToJump )
        {
            Jump();
            _readyToJump = false;
        }
    }

    private void MovePlayer()
    {
        // Movement direction
        Vector3 moveVector = transform.TransformDirection(_playerMovementInput) * moveSpeed;

        if (!_isGrounded )
        {
            moveVector *= airMultiplier;
        }

        // Apply movement by changing rigidBody velocity
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
    }

    private void Jump()
    {
        // Reset y velocity
        playerBody.velocity = new Vector3(playerBody.velocity.x, jumpForce, playerBody.velocity.z);
        
        // playerBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }
}