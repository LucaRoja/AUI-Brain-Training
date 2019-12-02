using System;
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

    // randomize list order? 
    public List<GameObject> spawnPrefabs = new List<GameObject>();
    public List<GameObject> spawned = new List<GameObject>();
    public int SpawnsPerStop = 4;
    public int UnSpawnsPerStop = 2;




    /*
    public void Spawn(int spawnPrefabIndex)
    {
        Spawn(spawnPrefabIndex, 0);
    }
    */
    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {
        spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation));
        spawnPrefabs.RemoveAt(spawnPrefabIndex);

    }

    public void UnSpawn()
    {
        GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];

        if (spawned.Count > 1)
            spawned.Remove(g);
            StartCoroutine(RemovePlayer(g));
        //else 

    }

    private IEnumerator RemovePlayer(GameObject g)
    {
        yield return new WaitForSeconds(5f);
        GameObject.DestroyImmediate(g);
    }



    void Start()
    {
        /*
        for (int i = 0; i < spawnPrefabs.Count; i++)
        {
            Spawn(1,2);
        }
        */
        bus.GetComponent<BusMovement>().manager = this;
    }


    private bool objSpawned;

    public void TestSpawn()
    {

        for (int i = 0; i < UnityEngine.Random.Range(0, SpawnsPerStop); i++)
            if (spawnPrefabs.Count > 0)
            {
                Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
                StartCoroutine(BusRestart());
            }
           // else
            {
             //   StartCoroutine(BusRestart());
            }






    }


    private IEnumerator BusRestart()
    {
        //UnSpawn();
        yield return new WaitForSeconds(1f);
        bus.GetComponent<BusMovement>().go = true;
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


  