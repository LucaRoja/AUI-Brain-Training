using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Object;
    public GameObject GameManager;
    public List<Sprite> sprites = new List<Sprite>();
    private GameObject go;

    ScreenLimits screenLimits;

    public int SpawnNumber = 6;
    public bool bounce = false;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;
    public bool black_and_white = false;

    public Screen2 screen;
    // Start is called before the first frame update
    void Awake()
    {

       
    }

    // Update is called once per frame
    void Start()
    {
        int j;
        for (int i = 0; i < SpawnNumber; i++)
        {
            if (!black_and_white)
            {
                j = UnityEngine.Random.Range(0, 12 - i);
            }
            else
            {
                j = UnityEngine.Random.Range(12, sprites.Count);
            }
            go = Instantiate(Object, screen.Random(), Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = sprites[j];
            go.name = "Object" + i;
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go.GetComponent<Movement>().GameManager = GameManager;
            go = Instantiate(Object, screen.Random(), Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sprite = sprites[j];
            go.name = "Object" + i;
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go.GetComponent<Movement>().GameManager = GameManager;
            sprites.Remove(sprites[j]);
        }
    }
}
