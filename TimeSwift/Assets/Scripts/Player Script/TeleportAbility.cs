using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAbility : MonoBehaviour
{
    [SerializeField] ListOfTeleporter activeTeleporters;
    [SerializeField] PlayerControls playerControls;
    Rigidbody rb;
    private void Awake()
    {
        activeTeleporters.InitializeQueue();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (Input.GetKeyDown(playerControls.teleportKey) && activeTeleporters.spawnedTeleporters.Count > 0)
        {
            rb.isKinematic = true;
            StartCoroutine(DisableKinematic());
            transform.position = activeTeleporters.spawnedTeleporters.Peek().transform.position;
            activeTeleporters.RemoveTeleporter();
        }
    }

    IEnumerator DisableKinematic()
    {
        yield return new WaitForSeconds(0.1f);
        rb.isKinematic = false;
    }
}
