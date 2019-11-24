using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject Circle;
    public GameObject Rectangle;
    public GameObject Elipse;
    public GameObject Star;

    public int SpawnNumber = 6;

    public Screen screen;


    void Awake()
    {
       //ObjectPoolingManager.Instance.CreatePool (Square, 100, 200);
        //ObjectPoolingManager.Instance.CreatePool (MeteorLarge, 20, 100);
        // ObjectPoolingManager.Instance.CreatePool (MeteorMedium, 20, 100);
        // ObjectPoolingManager.Instance.CreatePool (MeteorSmall, 20, 100);
        //ObjectPoolingManager.Instance.CreatePool (MeteorTiny, 20, 100);
        //ObjectPoolingManager.Instance.CreatePool (RegularExplosion, 20, 100);
        //ObjectPoolingManager.Instance.CreatePool (Ufo, 100, 200);

    }

    void Start()
    {
      //          for (int i = 1; i <= SpawnNumber; i++)
      //          {
      //             GameObject go = ObjectPoolingManager.Instance.GetObject (MeteorLarge.name);
      //              go.transform.position = screen.Random();
      //              go.transform.rotation = Quaternion.identity;
      //          }

    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.name == "Square")
            {
                Debug.Log("This is a Player");
            }
            else
            {
                Debug.Log("This isn't a Player");
            }
        }

    }

}