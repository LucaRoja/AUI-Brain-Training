using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject clicked;
    private Color color;
    private Renderer clickedRenderer;

    public int SpawnNumber = 6;
    public GameObject SpawnManager;
    public GameObject AudioManager;
    public bool bounce = false;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;

    private bool first = true;
    private int destroyed = 0;


    void Awake()
    {
        SpawnManager = Instantiate(SpawnManager);
        SpawnManager.GetComponent<SpawnManager>().SpawnNumber = SpawnNumber;
        SpawnManager.GetComponent<SpawnManager>().bounce = bounce;
        SpawnManager.GetComponent<SpawnManager>()._lower_velocity = _lower_velocity;
        SpawnManager.GetComponent<SpawnManager>()._upper_velocity = _upper_velocity;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && first && Input.GetMouseButtonDown(0))
        {
            clicked = hit.transform.gameObject;
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
                clickedRenderer.material.SetColor("_Color", color);
            }
        }
        if(destroyed == SpawnNumber)
        {
            Destroy(SpawnManager);
            RestartManager.gameOver();
            AudioManager.GetComponent<AudioManager>().gameWon();
        }
    }

}