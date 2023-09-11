using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerControls", menuName = "Player/Controls")]
public class PlayerControls : ScriptableObject
{
    public KeyCode spawnTeleporterKey = KeyCode.Mouse0;
    public KeyCode teleportKey = KeyCode.E;
    public KeyCode clearTeleporters = KeyCode.Q;
}
