using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTeleporter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerControls playerControls;
    [SerializeField] GameObject teleporterPrefab;
    [SerializeField] ListOfTeleporter activeTeleporters;
    [SerializeField] float maxTeleporters;
    [SerializeField] Transform playerCamera;
    [SerializeField] Animator anim;
    GameObject teleporter;

    [Header("Spawn Settings")]
    [SerializeField] float spawnDelay = 1f;

    [Header("RayCast")]
    [SerializeField] float raycastLength = Mathf.Infinity;
    [SerializeField] Vector3 obj;
    RaycastHit hit;
    bool objectDetected;
    

    private void Awake()
    {
       // playerCamera = Camera.main.transform;
    }
    private void Update()
    {
        ShootTeleporter();
        RemoveAllTeleporters();
    }

    private void ShootTeleporter()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if(Physics.Raycast(ray, out hit, raycastLength))
        {
            objectDetected = true;
            obj = hit.transform.position;
            if (Input.GetKeyDown(playerControls.spawnTeleporterKey) && activeTeleporters.spawnedTeleporters.Count < 3)
            {
                anim.SetTrigger("Shoot");
                StartCoroutine(Spawn());
            }
        }
        else { objectDetected = false; }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnDelay);
        teleporter = Instantiate(teleporterPrefab, playerCamera.transform.position, Quaternion.LookRotation(playerCamera.forward, Vector3.up));
        Vector3 teleportDirection = (hit.point - playerCamera.transform.position).normalized;
        teleporter.GetComponent<Teleporter>().SetTargetPos = teleportDirection;
        activeTeleporters.AddTeleporter(teleporter);
    }

    void RemoveAllTeleporters()
    {
        if(Input.GetKeyDown(playerControls.clearTeleporters) && activeTeleporters.spawnedTeleporters.Count > 0)
        {
            activeTeleporters.RemoveAllTeleporters();
        }
    }

    private void OnDrawGizmos()
    {
        if(objectDetected)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(playerCamera.position, playerCamera.transform.forward * 100f);
    }
}
