using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// refrence to all spawn points in level and list of all object we can spawn 

public class SpawnManagerBus : MonoSingleton<SpawnManagerBus>
{
    public GameObject TempGameObject;
    public GameObject bus;

    // declare and initialize lists
    public List<Transform> spawnPoint = new List<Transform>();

    public List<GameObject> spawnPrefabs = new List<GameObject>();
    public List<GameObject> spawned = new List<GameObject>();
    public int SpawnsPerStop = 4;
    public int UnspawnsPerStop = 2;





    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {

        //spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[(spawnPointIndex + 1)].position, spawnPoint[spawnPointIndex].rotation));
        //spawnPrefabs.RemoveAt(spawnPrefabIndex);

        if (spawnPrefabs.Count > 0)
        {
            TempGameObject = Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[(spawnPointIndex)].position, spawnPoint[spawnPointIndex].rotation);
            TempGameObject.GetComponent<CharacterMovement>().bus = bus;
            TempGameObject.GetComponent<CharacterMovement>().firstspawned = true;
            spawned.Add(TempGameObject);
            spawnPrefabs.RemoveAt(spawnPrefabIndex);
        }
        

    }


    public void UnSpawn()
    {
        //int spawnnum = 



        if ( spawned.Count > 1)
            {
            GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];
            g.GetComponent<CharacterMovement>().firstspawned = false;
            g.SetActive(true);
            g.transform.position = new Vector3(bus.transform.position.x, g.transform.position.y, 0) ;
            //Instantiate(g, bus.transform.position, Quaternion.identity);
            spawned.Remove(g);
            StartCoroutine(RemovePlayer(g));
            }

        unspawnnum++;

        if (unspawnnum == randomunspawn || randomunspawn == 0)
        {
            unspawnnum = 0;
            randomspawn = UnityEngine.Random.Range(0, SpawnsPerStop + 1);
            CancelInvoke();
            InvokeRepeating("BusSpawn", 0, 1);

        }

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

    private int spawnnum = 0;
    private int unspawnnum = 0;
    private int randomspawn;
    private int randomunspawn;

    public void BusSpawn()
    {

        Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
        spawnnum++;
        if (spawnnum == randomspawn || randomspawn == 0)
        {
            spawnnum = 0;
            CancelInvoke();
            StartCoroutine(BusRestart());

        }

    }

    public void TestSpawn()
    {
        //Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
        //StartCoroutine(BusRestart());

        randomunspawn = UnityEngine.Random.Range(0, UnspawnsPerStop + 1);
        InvokeRepeating("UnSpawn", 0, 1);

        /*
        for (int i = 0; i < UnityEngine.Random.Range(0, (SpawnsPerStop+1)); i++)
        {
            InvokeRepeating("BusSpawn", 1, 1);

            //Spawn(UnityEngine.Random.Range(0, spawnPrefabs.Count), bus.GetComponent<BusMovement>().currentstop);
            //yield return new WaitForSeconds(1f);
        }
        */




    }


    private IEnumerator BusRestart()
    {
        yield return new WaitForSeconds(5f);
        bus.GetComponent<BusMovement>().go = true;
    }
    
}








  