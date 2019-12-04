///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BusMovement : MonoSingleton<BusMovement>
public class BusMovement : MonoBehaviour

{
    public float speed = 5f;
    public int stops = 5;
    public bool go = true;
    private float x = -12.99f;
    public int currentstop = 0;
    public SpawnManagerBus manager;
    public GameObject SpawnBusManager;
    public GameObject BusStop;
    public List<GameObject> BusStops = new List<GameObject>();




    void Start()
    {
        x = transform.position.x + 102.38f / (stops);
        for (int i = 1; i <= stops; i++)
        {
            BusStops.Add(Instantiate(BusStop, new Vector3(i * 102.38f/(stops) , 0, 0), Quaternion.identity));

        }

    }

// Update is called once per frame

    void Update()
    {
        
            
        if (currentstop < stops && go == true)
        {
            
            if(transform.position.x < x)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                go = false;
                manager.TestSpawn();
                currentstop++;
                x = transform.position.x + 102.38f / (stops);
                }


        }

        if (currentstop == stops)
        {
            StartCoroutine(endgamewait());
        }
    }
    private IEnumerator endgamewait()
    {
        yield return new WaitForSeconds(7f);
        for (int i = 1; i <= stops; i++)
        {
            Destroy(BusStops[i-1]);


        }
        SpawnBusManager.GetComponent<SpawnManagerBus>().endgame();
    }
}
//*/

