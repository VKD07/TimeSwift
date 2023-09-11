using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "teleporter", menuName = "Teleporter")]
public class ListOfTeleporter : ScriptableObject
{
    public Queue<GameObject> spawnedTeleporters;

    public void InitializeQueue()
    {
        spawnedTeleporters = new Queue<GameObject>();
    }

    public void AddTeleporter(GameObject teleporter)
    {
        spawnedTeleporters.Enqueue(teleporter);
    }

    public void RemoveTeleporter()
    {
        if (spawnedTeleporters.Count > 0)
        {
            GameObject removedTeleporter = spawnedTeleporters.Dequeue();
            Destroy(removedTeleporter);
        }
    }

    public void RemoveAllTeleporters()
    {
        foreach (GameObject teleporter in spawnedTeleporters)
        {
            Destroy(teleporter);
        }
        spawnedTeleporters.Clear();
    }

    private void OnDisable()
    {
        RemoveAllTeleporters();
    }
}
