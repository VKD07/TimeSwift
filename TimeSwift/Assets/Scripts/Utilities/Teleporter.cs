using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Teleporter : MonoBehaviour
{
    public float moveSpeed = 100f;
    Vector3 targetPos;

    Rigidbody rb;

    #region Getter Setter
    public Vector3 SetTargetPos { set { targetPos = value; } }
    #endregion

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
        if (targetPos != null)
        {
            rb.velocity =  targetPos * moveSpeed * Time.deltaTime;
        }
    }
}
