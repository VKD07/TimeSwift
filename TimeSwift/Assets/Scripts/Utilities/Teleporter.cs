using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Teleporter : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        rb.velocity = transform.forward * moveSpeed * Time.deltaTime;
    }
}
