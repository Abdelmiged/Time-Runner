using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerCar : MonoBehaviour
{
    Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player;
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        player = (ScenesGlobalVariables.player != null) ? ScenesGlobalVariables.player : Resources.Load<GameObject>("Prefabs/Cars/Hatchback_Moving");
        player.transform.position = spawnPoint.position;
        Instantiate(player);
    }
}
