using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeleporter : MonoBehaviour
{
    [SerializeField] PlayerControls playerControls;
    [SerializeField] GameObject teleporterPrefab;
    [SerializeField] ListOfTeleporter activeTeleporters;
    [SerializeField] float maxTeleporters;
    Transform playerCamera;
    GameObject teleporter;

    private void Awake()
    {
        playerCamera = Camera.main.transform;
    }
    private void Update()
    {
        ShootTeleporter();
        RemoveAllTeleporters();
    }

    private void ShootTeleporter()
    {
        if (Input.GetKeyDown(playerControls.spawnTeleporterKey) && activeTeleporters.spawnedTeleporters.Count < 3)
        {
            teleporter = Instantiate(teleporterPrefab, playerCamera.transform.position, Quaternion.LookRotation(playerCamera.forward, Vector3.up));
            teleporter.transform.forward = playerCamera.forward;
            activeTeleporters.AddTeleporter(teleporter);
        }
    }

    void RemoveAllTeleporters()
    {
        if(Input.GetKeyDown(playerControls.clearTeleporters) && activeTeleporters.spawnedTeleporters.Count > 0)
        {
            activeTeleporters.RemoveAllTeleporters();
        }
    }
}
