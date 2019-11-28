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
        //spawnPrefabs.Remove(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation));

    }

    public void UnSpawn()
    {
        GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];
        spawned.Remove(g);
        StartCoroutine(RemovePlayer(g));
    }

    private IEnumerator RemovePlayer(GameObject g)
    {
        yield return new WaitForSeconds(3f);
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
       
        Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
        
        StartCoroutine(BusRestart());

    }



    private IEnumerator BusRestart()
    {
        UnSpawn();
        yield return new WaitForSeconds(3f);
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


  