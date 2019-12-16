using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject clickedRight;
    private GameObject clickedLeft;
    private Color colorRight;
    private Color colorLeft;
    private GameObject clicked;
    private GameObject clicked2;
    private Color color1;
    private Color color2;
    private bool once = true;
    public KinectBodySkeleton skeleton;

    public int SpawnNumber = 12;
    public GameObject SpawnManager;
    public GameObject AudioManager;
    public bool bounce = false;
    public bool black_and_white = false;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;
    public InputField SpawnInput;
    public InputField MinimumInput;
    public InputField MaximumInput;
    private GameObject selectionMenu;
    int integer_Value_we_Want;

    private bool first = true;
    private bool second = false;
    public int destroyed = 0;

    private void Awake()
    {
        selectionMenu = GameObject.Find("SelectionMenu");  
    }
    public void startGame()
    {
        SpawnNumber = int.Parse(SpawnInput.text); //for integer 
        _lower_velocity = float.Parse(MinimumInput.text);
        _upper_velocity = float.Parse(MaximumInput.text);
        selectionMenu.SetActive(false);
        SpawnManager = Instantiate(SpawnManager);
        SpawnManager.GetComponent<SpawnManager>().SpawnNumber = SpawnNumber;
        SpawnManager.GetComponent<SpawnManager>().GameManager = gameObject;
        SpawnManager.GetComponent<SpawnManager>().bounce = bounce;
        SpawnManager.GetComponent<SpawnManager>()._lower_velocity = _lower_velocity;
        SpawnManager.GetComponent<SpawnManager>()._upper_velocity = _upper_velocity;
        SpawnManager.GetComponent<SpawnManager>().black_and_white = black_and_white;
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(skeleton.HandRight.x, skeleton.HandRight.y), Vector2.zero);
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(skeleton.HandLeft.x, skeleton.HandLeft.y), Vector2.zero);
        if(hitRight.collider != null && skeleton.isRightHandClosed(0.07f))
        {
            clickedRight = hitRight.transform.gameObject;
            clickedRight.GetComponent<Movement>().follow = true;
            clickedRight.GetComponent<Rigidbody2D>().isKinematic = false;
            colorRight = clickedRight.GetComponent<Renderer>().material.GetColor("_Color");
            clickedRight.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else if(hitRight.collider != null)
        {
            clickedRight.GetComponent<Movement>().follow = false;
            clickedRight.GetComponent<Renderer>().material.SetColor("_Color", colorRight);
            clickedRight.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if (hitLeft.collider != null && skeleton.isLeftHandClosed(0.07f))
        {
            clickedLeft = hitLeft.transform.gameObject;
            clickedLeft.GetComponent<Movement>().follow = true;
            clickedLeft.GetComponent<Rigidbody2D>().isKinematic = false;
            colorLeft = clickedLeft.GetComponent<Renderer>().material.GetColor("_Color");
            clickedLeft.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
        }
        else if (hitLeft.collider != null)
        {
            clickedLeft.GetComponent<Movement>().follow = false;
            clickedLeft.GetComponent<Renderer>().material.SetColor("_Color", colorLeft);
            clickedLeft.GetComponent<Movement>().first = false;
            clickedLeft.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        /*
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
         else if(!first && second && Input.GetMouseButtonUp(0))
         {
             clicked2.GetComponent<Movement>().follow = false;
             clicked2.GetComponent<Renderer>().material.SetColor("_Color", color2);
             clicked2.GetComponent<Rigidbody2D>().isKinematic = true;
             second = false;
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
            }
        }
        else
            once = true;
            /*
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
                    clicked2.GetComponent<Renderer>().material.SetColor("_Color", color2);
                    clicked2.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
            else
                once = true;
                */
                
        }
    public void ChangeBlackAndWhite()
    {
        black_and_white = !black_and_white;
    }

}