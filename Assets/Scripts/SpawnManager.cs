using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Square;
    public GameObject Triangle;
    public GameObject Circle;
    public GameObject Rectangle;
    public GameObject Elipse;
    public GameObject Star;
    private List<GameObject> spawnPrefabs = new List<GameObject>();
    private GameObject go;

    ScreenLimits screenLimits;

    public int SpawnNumber = 6;
    public bool bounce = false;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;

    public Screen screen;
    // Start is called before the first frame update
    void Awake()
    {

       
    }

    // Update is called once per frame
    void Start()
    {
        spawnPrefabs.Add(Square);
        spawnPrefabs.Add(Triangle);
        spawnPrefabs.Add(Circle);
        spawnPrefabs.Add(Rectangle);
        spawnPrefabs.Add(Elipse);
        spawnPrefabs.Add(Star);

        for(int i = 0; i < SpawnNumber; i++)
        {
            int j = UnityEngine.Random.Range(0, spawnPrefabs.Count);
            go = Instantiate(spawnPrefabs[j], screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(spawnPrefabs[j], screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            spawnPrefabs.Remove(spawnPrefabs[j]);
        }
    }
}
