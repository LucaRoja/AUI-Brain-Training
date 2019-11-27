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
        spawned.Remove(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[spawnPointIndex].position, spawnPoint[spawnPointIndex].rotation));

    }


    void Start()
    {
        /*
        for (int i = 0; i < spawnPrefabs.Count; i++)
        {
            Spawn(1,2);
        }
        */
    }

    private bool objSpawned;
    void Update()
    {
        if (bus.GetComponent<BusMovement>().go == false)// && bus.GetComponent<BusMovement>().currentstop == 1) //characters on bus )
        {

            if (bus.GetComponent<BusMovement>().currentstop == 1)
            {
                Spawn(1, 1);
            }
            else if (bus.GetComponent<BusMovement>().currentstop == 2)
            {
                Spawn(1, 2);
            }
            else if (bus.GetComponent<BusMovement>().currentstop == 3)
            {
                Spawn(1, 3);
            }
            else if (bus.GetComponent<BusMovement>().currentstop == 4)
            {
                Spawn(1, 4);
            }
            else if (bus.GetComponent<BusMovement>().currentstop == 5)
            {
                Spawn(1, 5);
            }


            // spawn number at stop one, remove number 
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


  