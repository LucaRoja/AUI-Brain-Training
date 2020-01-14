using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private bool onlyOneRight = true;
    private bool onlyOneLeft = true;
    private bool once = true;
    public KinectBodySkeleton skeleton;
    KinectBodySkeleton temporarySkeleton;
    public List<Sprite> backgrounds = new List<Sprite>();

    public int SpawnNumber = 12;
    public GameObject SpawnManager;
    public GameObject AudioManager;
    public GameObject feetObject;
    public bool bounce = false;
    public Toggle black_and_white;
    public Toggle colorOutline;
    public Toggle patternBW;
    public Toggle patternColor;
    public Toggle FeetToggle;
    public Toggle blackBackground;
    public Toggle confettiBackground;
    public Toggle iceBackground;
    public Toggle robotBackground;
    public Toggle TVBackground;
    public float _lower_velocity = 3.0f;
    public float _upper_velocity = 6.0f;
    public InputField SpawnInput;
    public InputField MinimumInput;
    public InputField MaximumInput;
    private GameObject selectionMenu;
    private GameObject rightHand;
    private GameObject leftHand;
    private GameObject _background;
    int integer_Value_we_Want;

    private bool first = true;
    private bool second = false;
    private bool feet = false;
    private bool onthefeet = true;
    private float notOnFeet = 0f;
    private float onFeet = 0f;
    private float timePassed = 0f;
    public int destroyed = 0;

    private void Start()
    {
        MagicRoomKinectV2Manager.instance.setUpKinect(5, 1);
        MagicRoomKinectV2Manager.instance.startSamplingKinect(KinectSamplingMode.Streaming);

    }
    private void Awake()
    {
        selectionMenu = GameObject.Find("SelectionMenu");
        rightHand = GameObject.Find("RightHand");
        leftHand = GameObject.Find("LeftHand");
        rightHand.transform.GetChild(1).gameObject.SetActive(false);
        leftHand.transform.GetChild(1).gameObject.SetActive(false);
        feetObject.SetActive(false);
        _background = GameObject.Find("Background");
       // MagicRoomLightManager.instance.sendColour(color.white, 0);
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
        SpawnManager.GetComponent<SpawnManager>().black_and_white = black_and_white.isOn;
        SpawnManager.GetComponent<SpawnManager>().colorOutline = colorOutline.isOn;
        SpawnManager.GetComponent<SpawnManager>().patternBW = patternBW.isOn;
        SpawnManager.GetComponent<SpawnManager>().patternColor = patternColor.isOn;
        if(blackBackground.isOn)
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[0];
        if(confettiBackground.isOn)
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[1];
        if(iceBackground.isOn)
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[2];
        if(robotBackground.isOn)
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[3];
        if(TVBackground.isOn)
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[4];
        feet = FeetToggle.isOn;
        if(feet)
            feetObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (MagicRoomKinectV2Manager.instance.MagicRoomKinectV2Manager_active)
        {
            temporarySkeleton = null;

            foreach(KinectBodySkeleton c in MagicRoomKinectV2Manager.instance.skeletons) 
            {
                //Debug.Log(c);
                if(temporarySkeleton == null && c.SpineBase.z > 0)
                {
                    temporarySkeleton = c;
                }
                else if(temporarySkeleton == null)
                    continue;
                else if(temporarySkeleton.SpineBase.z > c.SpineBase.z && c.SpineBase.z > 0)
                {
                    temporarySkeleton = c;
                }
            }
            skeleton = temporarySkeleton;
            RaycastHit2D hitRight = Physics2D.Raycast(new Vector2((skeleton.HandRight.x* 9f),( skeleton.HandRight.y* 5f)), Vector2.zero);
            RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2((skeleton.HandLeft.x*9f) ,( skeleton.HandLeft.y*5f)), Vector2.zero);
            if(feet)
            {
                timePassed += Time.deltaTime;
                    if(((skeleton.SpineBase.x + 0.7f)*6.35f) + 14.2f < feetObject.GetComponent<Transform>().position.x + 1.5f && ((skeleton.SpineBase.x + 0.7f)*6.35f) + 14.2f > feetObject.GetComponent<Transform>().position.x - 1.5)
                    {
                        onthefeet = true;
                        onFeet += Time.deltaTime;
                        //MagicRoomLightManager.instance.sendColour(Color.green, 40);
                        notOnFeet = 0;
                    }
                    else 
                    {
                        onFeet = 0;
                        notOnFeet += Time.deltaTime;
                        onthefeet = false;
                    }
                    if(notOnFeet > 2)
                    {
                        MagicRoomLightManager.instance.sendColour(Color.red, 100);
                        notOnFeet = 0;
                    }
                    if(onFeet > 2)
                    {
                        MagicRoomLightManager.instance.sendColour(Color.blue, 40);
                        onFeet = 0;
                    }

                if(timePassed > 15f)
                {
                    feetObject.GetComponent<Transform>().position = new Vector3(UnityEngine.Random.Range(16,23), -1.8f);
                    timePassed = 0;
                    MagicRoomLightManager.instance.sendColour(Color.red, 40);
                    onFeet = 1;
                }
            }
            if (hitRight.collider != null && skeleton.isRightHandClosed(0.07f) && onlyOneRight && onthefeet)
            {
                clickedRight = hitRight.transform.gameObject;
                clickedRight.GetComponent<Movement>().follow = true;
                clickedRight.GetComponent<Rigidbody2D>().isKinematic = false;
                clickedRight.GetComponent<Movement>().follow_x = skeleton.HandRight.x* 9f;
                clickedRight.GetComponent<Movement>().follow_y = skeleton.HandRight.y*5f;
                colorRight = clickedRight.GetComponent<Renderer>().material.GetColor("_Color");
                clickedRight.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
                onlyOneRight = false;
            }
            else if (clickedRight != null)
            {
                clickedRight.GetComponent<Movement>().follow = false;
                clickedRight.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                clickedRight.GetComponent<Rigidbody2D>().isKinematic = true;
                onlyOneRight = true;
            }
            else 
                 onlyOneRight = true;
            if (hitLeft.collider != null && skeleton.isLeftHandClosed(0.07f) && onlyOneLeft && onthefeet)
            {
                clickedLeft = hitLeft.transform.gameObject;
                clickedLeft.GetComponent<Movement>().follow = true;
                clickedLeft.GetComponent<Rigidbody2D>().isKinematic = false;
                clickedLeft.GetComponent<Movement>().follow_x = skeleton.HandLeft.x* 9f;
                clickedLeft.GetComponent<Movement>().follow_y = skeleton.HandLeft.y*5f;
                colorLeft = clickedLeft.GetComponent<Renderer>().material.GetColor("_Color");
                clickedLeft.GetComponent<Renderer>().material.SetColor("_Color", Color.gray);
                onlyOneLeft = false;
            }
            else if (clickedLeft != null)
            {
                clickedLeft.GetComponent<Movement>().follow = false;
                clickedLeft.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                clickedLeft.GetComponent<Movement>().first = false;
                clickedLeft.GetComponent<Rigidbody2D>().isKinematic = true;
                onlyOneLeft = true;
            }
            else 
                onlyOneLeft = true;
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
            feet = false;
            _background.GetComponent<SpriteRenderer>().sprite = backgrounds[5];
            AudioManager.GetComponent<AudioManager>().gameWon();
        }
        if (skeleton.isRightHandClosed(0.07f))
        {
            rightHand.transform.GetChild(1).gameObject.SetActive(true);
            rightHand.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            rightHand.transform.GetChild(1).gameObject.SetActive(false);
            rightHand.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (skeleton.isLeftHandClosed(0.07f))
        {
            leftHand.transform.GetChild(1).gameObject.SetActive(true);
            leftHand.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            leftHand.transform.GetChild(1).gameObject.SetActive(false);
            leftHand.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void weCollided(bool right)
    {
        
        if (once)
        {
            once = false;
            if (right)
            {
                AudioManager.GetComponent<AudioManager>().ShapeMatch();
                destroyed++;
                StartCoroutine(changeColor(Color.green));
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

    IEnumerator changeColor(Color c)
    {
        MagicRoomLightManager.instance.sendColour(c, 100);
        yield return new WaitForSeconds(0.5f);
        MagicRoomLightManager.instance.sendColour(Color.green, 0);
    }
    
    public void ChangeBlackAndWhite()
    {
        if (black_and_white.isOn)
        {
            colorOutline.isOn = false;
            patternBW.isOn = false;
            patternColor.isOn = false;

        }

    }
    public void ChangeColorOutline()
    {
        if (colorOutline.isOn)
        {
            black_and_white.isOn = false;
            patternBW.isOn = false;
            patternColor.isOn = false;

        }
    }
    public void ChangePatternBW()
    {
        if (patternBW.isOn)
        {
            black_and_white.isOn = false;
            colorOutline.isOn = false;
            patternColor.isOn = false;

        }
    }
    public void ChangePatternColor()
    {
        if (patternColor.isOn)
        {
            black_and_white.isOn = false;
            colorOutline.isOn = false;
            patternBW.isOn = false;

        }
    }
    

    public void backToTheMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("MenuManager").GetComponent<MainMenuManager>().backToMenu();
    }
    
    public void ChangeBlackBackground()
    {
        if (blackBackground.isOn)
        {
            confettiBackground.isOn = false;
            iceBackground.isOn = false;
            robotBackground.isOn = false;
            TVBackground.isOn = false;

        }
    }
    public void ChangeConfetti()
    {
        if (confettiBackground.isOn)
        {
            blackBackground.isOn = false;
            iceBackground.isOn = false;
            robotBackground.isOn = false;
            TVBackground.isOn = false;

        }
    }
    public void ChangeIceBackground()
    {
        if (iceBackground.isOn)
        {
            confettiBackground.isOn = false;
            blackBackground.isOn = false;
            robotBackground.isOn = false;
            TVBackground.isOn = false;

        }
    }

    public void ChangeRobotBackground()
    {
        if (robotBackground.isOn)
        {
            confettiBackground.isOn = false;
            blackBackground.isOn = false;
            iceBackground.isOn = false;
            TVBackground.isOn = false;

        }
    }

    public void ChangeTVBackground()
    {
        if (TVBackground.isOn)
        {
            confettiBackground.isOn = false;
            blackBackground.isOn = false;
            robotBackground.isOn = false;
            iceBackground.isOn = false;

        }
    }
}