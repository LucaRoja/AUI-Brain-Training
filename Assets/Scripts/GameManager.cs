using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject clicked;
    private GameObject clicked2;
    private Color color1;
    private Color color2;
    private Renderer clickedRenderer;
    private bool once = true;

    public int SpawnNumber = 12;
    public GameObject SpawnManager;
    public GameObject AudioManager;
    public bool bounce = false;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;

    private bool first = true;
    private bool second = false;
    public int destroyed = 0;
        

    void Awake()
    {
        SpawnManager = Instantiate(SpawnManager);
        SpawnManager.GetComponent<SpawnManager>().SpawnNumber = SpawnNumber;
        SpawnManager.GetComponent<SpawnManager>().GameManager = gameObject;
        SpawnManager.GetComponent<SpawnManager>().bounce = bounce;
        SpawnManager.GetComponent<SpawnManager>()._lower_velocity = _lower_velocity;
        SpawnManager.GetComponent<SpawnManager>()._upper_velocity = _upper_velocity;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && Input.GetMouseButtonDown(0))
        {
            if (first)
            {
                clicked = hit.transform.gameObject;
                clicked.GetComponent<Movement>().follow = true;
                clicked.GetComponent<Rigidbody2D>().isKinematic = false;
                first = false;
                clicked.GetComponent<Movement>().first = true;
                color1 = clicked.GetComponent<Renderer>().material.GetColor("_Color");
                clicked.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            }
            else if(!second && hit.transform.gameObject != clicked)
            {
                clicked2 = hit.transform.gameObject;
                clicked2.GetComponent<Movement>().follow = true;
                clicked2.GetComponent<Rigidbody2D>().isKinematic = false;
                second = true;
                color2 = clicked2.GetComponent<Renderer>().material.GetColor("_Color");
                clicked2.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
            }
        }

       /* if (hit.collider != null && first && Input.GetMouseButtonDown(0))
        {
            clicked = hit.transform.gameObject;
            clicked.GetComponent<Movement>().follow = true;
            first = false;
            //Get the Renderer component from the new cube
            clickedRenderer = clicked.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            color = clickedRenderer.material.GetColor("_Color");
            clickedRenderer.material.SetColor("_Color", Color.gray);

        }
        else if (hit.collider != null && !first && Input.GetMouseButtonDown(0) && hit.transform.gameObject != clicked)
        {
            first = true;
            if(clicked.name == hit.transform.name)
            {
                Destroy(clicked);
                Destroy(hit.transform.gameObject);
                destroyed += 1;
                //play rewarding sound
            }
            else
            {
                clicked.GetComponent<Movement>().follow = false;
                clickedRenderer.material.SetColor("_Color", color);
            }
        }
        */
        if (destroyed == SpawnNumber)
        {
            destroyed = 0;
            Destroy(SpawnManager);
            RestartManager.gameOver();
            AudioManager.GetComponent<AudioManager>().gameWon();
        }
    }
    public void weCollided(bool right)
    {
        if (once)
        {
            once = false;
            if (right)
            {
                destroyed++;
                first = true;
                second = false;
            }
            else
            {
                first = true;
                second = false;
                clicked.GetComponent<Movement>().follow = false;
                clicked.GetComponent<Renderer>().material.SetColor("_Color", color1);
                clicked.GetComponent<Movement>().first = false;
                clicked.GetComponent<Rigidbody2D>().isKinematic = true;
                clicked2.GetComponent<Movement>().follow = false;
                clicked2.GetComponent<Renderer>().material.SetColor("_Color", color1);
                clicked2.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        else
            once = true;
    }


}