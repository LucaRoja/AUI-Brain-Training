﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// refrence to all spawn points in level and list of all object we can spawn 

public class SpawnManagerBus : MonoSingleton<SpawnManagerBus>
{
    public GameObject Square;
    public GameObject bus;
    // declare and initialize lists
    public List<Transform> spawnPoint = new List<Transform>();
    public List<GameObject> spawnPrefabs = new List<GameObject>();
    public List<GameObject> spawned = new List<GameObject>();





    public void Spawn(int spawnPrefabIndex)
    {
        Spawn(spawnPrefabIndex, 0);
    }
    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {
        spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation));
    }

 /*   
    public static void Main()
    {
        public int ObjectNum = spawnPrefabs.Count();
    }
*/    

    void Start()
    {
        for (int i = 0; i < spawnPrefabs.Count; i++)
        {
            Spawn(i);
        }

    }

    void Update()
    {
        if (bus.GetComponent<BusMovement>().go == false ) //characters on bus )
        {
            // move to stop 
        }

    }
}


 /*   
    //Temp
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Spawn(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Spawn(1);

    }
}
*/


  