using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] Transform direction;
    [SerializeField] float groundDrag;
    [Header("Grounded")]
    [SerializeField] float playerHeight;
    [SerializeField] LayerMask whatIsGround;
    bool grounded;

    float horizontal;
    float forward;
    Vector3 moveDirection;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInput();
        GroundCheck();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void MoveInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        forward = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        moveDirection = direction.forward * forward + direction.right * horizontal;
        rb.AddForce(moveDirection.normalized * movementSpeed * 10, ForceMode.Force);
    }
    private void GroundCheck()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5F + 0.2f, whatIsGround);

        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
