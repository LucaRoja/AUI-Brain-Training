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
        //screenLimits.bounce = bounce;
        if (SpawnNumber >= 1)
        {
            go = Instantiate(Square, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Square, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }
        if (SpawnNumber >= 2)
        {
            go = Instantiate(Circle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Circle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }
        if (SpawnNumber >= 3)
        {
            go = Instantiate(Triangle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Triangle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }
        if (SpawnNumber >= 4)
        {
            go = Instantiate(Star, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Star, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }
        if (SpawnNumber >= 5)
        {
            go = Instantiate(Rectangle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Rectangle, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }
        if (SpawnNumber >= 6)
        {
            go = Instantiate(Elipse, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
            go = Instantiate(Elipse, screen.Random(), Quaternion.identity);
            go.GetComponent<ScreenLimits>().bounce = bounce;
            go.GetComponent<Movement>()._lower_velocity = _lower_velocity;
            go.GetComponent<Movement>()._upper_velocity = _upper_velocity;
        }

    }
}
