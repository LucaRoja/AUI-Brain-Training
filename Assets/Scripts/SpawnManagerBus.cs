﻿using System;
using System.Collections;
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
    public int SpawnsPerStop = 4;
    public int UnSpawnsPerStop = 2;





    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {

        //spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[(spawnPointIndex + 1)].position, spawnPoint[spawnPointIndex].rotation));
        //spawnPrefabs.RemoveAt(spawnPrefabIndex);

        if (spawnPrefabs.Count > 0)
        {
            spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[(spawnPointIndex + 1)].position, spawnPoint[spawnPointIndex].rotation));
            spawnPrefabs.RemoveAt(spawnPrefabIndex);
        }
        

    }

    public void UnSpawn()
    {
        GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];
        spawned.Remove(g);
        StartCoroutine(RemovePlayer(g));

        //GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];

        /*
        if (spawned.Count > 1)
        {
            spawned.Remove(g);
            Spawn((int g), bus.GetComponent<BusMovement>().currentstop);
            //Instantiate(g, spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation);
            StartCoroutine(RemovePlayer(g));

        }
        else
        {
            StartCoroutine(RemovePlayer(g));

        }
        */
        


    }

    private IEnumerator RemovePlayer(GameObject g)
    {
        yield return new WaitForSeconds(3f);
        GameObject.DestroyImmediate(g);
    }



    void Start()
    {
        bus.GetComponent<BusMovement>().manager = this;
    }


    private bool objSpawned;

    public void TestSpawn()
    {
        Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
        StartCoroutine(BusRestart());
        
        for (int i = 0; i < UnityEngine.Random.Range(0, SpawnsPerStop); i++)
            Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
            StartCoroutine(BusRestart());



    }


    private IEnumerator BusRestart()
    {
        //UnSpawn();
        yield return new WaitForSeconds(1f);
        bus.GetComponent<BusMovement>().go = true;
    }
}





  