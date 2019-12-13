using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// refrence to all spawn points in level and list of all object we can spawn 

public class SpawnManagerBus : MonoSingleton<SpawnManagerBus>
{
    public GameObject TempGameObject;
    public GameObject bus;
    public GameObject scenery;

    // declare and initialize lists

    public List<GameObject> spawnPrefabs = new List<GameObject>();
    public List<GameObject> spawned = new List<GameObject>();
    public int SpawnsPerStop = 4;
    public int UnspawnsPerStop = 2;
    public float _CharacterSpeed = -2;
    public bool _buckethat = false;
    public bool _cold = false;
    public bool _egg = false;
    public bool _flower = false;
    public bool _glasses = false;
    public bool _jenny = false;
    public bool _lightblue = false;
    public bool _pentagon = false;
    public bool _royal = false;
    public bool _sassypink = false;
    public bool _star = false;
    public bool _tophat = false;

    private GameObject _ResultText;
    private GameObject _EndGameMenu;

    void Start()
    {
        _EndGameMenu = GameObject.Find("EndGameMenu");
        _ResultText = GameObject.Find("_ResultText");

        _EndGameMenu.SetActive(false);
        bus.GetComponent<BusMovement>().manager = this;

        

    }



    public void Spawn(int spawnPrefabIndex, int spawnPointIndex)
    {

        //spawned.Add(Instantiate(spawnPrefabs[spawnPrefabIndex], spawnPoint[(spawnPointIndex + 1)].position, spawnPoint[spawnPointIndex].rotation));
        //spawnPrefabs.RemoveAt(spawnPrefabIndex);

        if (spawnPrefabs.Count > 0)
        {
            Vector3 spawnposition = new Vector3(bus.transform.position.x + 12, bus.transform.position.y, 0);
            TempGameObject = Instantiate(spawnPrefabs[spawnPrefabIndex], spawnposition, Quaternion.identity);
            Debug.Log(TempGameObject.name);
            TempGameObject.GetComponent<CharacterMovement>().bus = bus;
            TempGameObject.GetComponent<CharacterMovement>().firstspawned = true;
            spawned.Add(TempGameObject);
            spawnPrefabs.RemoveAt(spawnPrefabIndex);
        }
        

    }


    public void UnSpawn()
    {


        if ( spawned.Count > 1)
            {
            GameObject g = spawned[UnityEngine.Random.Range(0, spawned.Count)];
            g.GetComponent<CharacterMovement>().firstspawned = false;
            g.SetActive(true);
            g.transform.position = new Vector3(bus.transform.position.x + 1.5f, g.transform.position.y, 0) ;
            //Instantiate(g, bus.transform.position, Quaternion.identity);
            spawned.Remove(g);
            //StartCoroutine(RemovePlayer(g));
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

    /*
    private IEnumerator RemovePlayer(GameObject g)
    {
        yield return new WaitForSeconds(3f);
        GameObject.DestroyImmediate(g);
    }
    */



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

    public void endgame()
    {
        _EndGameMenu.SetActive(true);
        scenery.SetActive(false);
        bus.SetActive(false);
    }

    public void checkResults()
    {
        for(int i = 0; i < spawned.Count; i++)
        {
            if (spawned[i].name == "Character_BucketHat(Clone)")
                _buckethat = !_buckethat;
            if (spawned[i].name == "Character_Cold(Clone)")
                _cold = !_cold;
            if (spawned[i].name == "Character_Egg(Clone)")
                _egg = !_egg;
            if (spawned[i].name == "Character_Flower(Clone)")
                _flower = !_flower;
            if (spawned[i].name == "Character_Glasses(Clone)")
                _glasses = !_glasses;
            if (spawned[i].name == "Character_Jenny(Clone)")
                _jenny = !_jenny;
            if (spawned[i].name == "Character_LightBlue(Clone)")
                _lightblue = !_lightblue;
            if (spawned[i].name == "Character_Pentagon(Clone)")
                _pentagon = !_pentagon;
            if (spawned[i].name == "Character_Royal(Clone)")
                _royal = !_royal;
            if (spawned[i].name == "Character_SassyPink(Clone)")
                _sassypink = !_sassypink;
            if (spawned[i].name == "Character_Star(Clone)")
                _star = !_star;
            if (spawned[i].name == "Character(_TopHatClone)")
                _tophat = !_tophat;

        }
        _EndGameMenu.SetActive(false);
        _ResultText.SetActive(true);
        if ( _buckethat || _cold || _egg || _flower || _glasses || _jenny || _lightblue || _pentagon || _royal || _sassypink || _star || _tophat )
        {
            _ResultText.GetComponent<Text>().text = "Try Again!";

        }
        else
        _ResultText.GetComponent<Text>().text = "Try Again!";
    }


    #region ToggleFUNctions
    public void buckethatpress()
    {
        _buckethat = !_buckethat;
    }
    public void coldpress()
    {
        _cold = !_cold;
    }
    public void eggpress()
    {
        _egg = !_egg;
    }
    public void flowerpress()
    {
        _flower = !_flower;
    }
    public void glassespress()
    {
        _glasses = !_glasses;
    }
    public void jennypress()
    {
        _jenny = !_jenny;
    }
    public void lightbluepress()
    {
        _lightblue = !_lightblue;
    }
    public void pentagonpress()
    {
        _pentagon = !_pentagon;
    }
    public void royalpress()
    {
        _royal = !_royal;
    }
    public void sassypinkpress()
    {
        _sassypink = !_sassypink;
    }
    public void starpress()
    {
        _star = !_star;
    }
    public void tophatpress()
    {
        _tophat = !_tophat;
    }
    #endregion
}








