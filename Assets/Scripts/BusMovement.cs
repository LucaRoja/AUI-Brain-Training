///*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class BusMovement : MonoSingleton<BusMovement>
public class BusMovement : MonoBehaviour

{
    public float speed = 5f;
    public int stops = 5;
    public int trees = 5;
    public int birds = 5;

    public bool go = true;
    private float x = -12.99f;
    public int currentstop = 0;
    public SpawnManagerBus manager;
    public GameObject SpawnBusManager;
    public GameObject BusStop;
    public List<GameObject> BusStops = new List<GameObject>();
    public GameObject Tree;
    public List<GameObject> Trees = new List<GameObject>();
    public GameObject Bird;
    public List<GameObject> Birds = new List<GameObject>();




    void Awake()
    {
        stops = GameObject.Find("MenuManager").GetComponent<MainMenuManager>()._numberOfStops;
        birds = GameObject.Find("MenuManager").GetComponent<MainMenuManager>()._birds;
        trees = GameObject.Find("MenuManager").GetComponent<MainMenuManager>()._trees;
        speed = GameObject.Find("MenuManager").GetComponent<MainMenuManager>()._busVelocity;
        x = transform.position.x + 200f / (stops);
        for (int i = 1; i <= stops; i++)
        {
            BusStops.Add(Instantiate(BusStop, new Vector3(i * 200f / (stops) - 5, -0.64f, 0), Quaternion.identity));

        }
        for (int i = 1; i <= trees; i++)
        {
            Trees.Add(Instantiate(Tree, new Vector3(i * 200f / (trees), -0.57f, 0), Quaternion.identity));

        }
        for (int i = 1; i <= birds; i++)
        {
            Birds.Add(Instantiate(Bird, new Vector3(i * 200f / (birds), 4.5f, 0), Quaternion.identity));

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
                x = transform.position.x + 200f / (stops);
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
        for (int i = 1; i <= trees; i++)
        {
            Destroy(Trees[i - 1]);

        }
        SpawnBusManager.GetComponent<SpawnManagerBus>().endgame();
    }
}
//*/

