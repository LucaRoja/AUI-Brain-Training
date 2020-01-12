using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : Singleton<MainMenuManager>
{
    public InputField NumberOfStops;
    public InputField busVelocity;
    public InputField NumberOfSpawns;
    public InputField NumberOfDespawns;
    public InputField NumberOfTrees;
    public InputField NumberOfBirds;
    private GameObject _busSelection;
    private GameObject _bus;
    private GameObject _busSpawn;
    private bool justLoaded = false;
    public int _numberOfStops;
    public float _busVelocity;
    public int _numberOfSpawns;
    public int _numberOfDespawns;
    public int _birds;
    public int _trees;
    // Start is called before the first frame update
    void Start()
    {
        _busSelection = GameObject.Find("BusGameSelection");
        _busSelection.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu" && justLoaded)
        {
            _busSelection = GameObject.Find("BusGameSelection");
            _busSelection.SetActive(false);
            justLoaded = false;
            GameObject.Find("TwinButton").GetComponent<Button>().onClick.AddListener(clickButton1);
            GameObject.Find("BusButton").GetComponent<Button>().onClick.AddListener(clickButton2);
        }
    }

    public void clickButton1()
    {
        SceneManager.LoadScene("TwinColors");
    }

    public void clickButton2()
    {
        _busSelection.SetActive(true);
        GameObject.Find("SelectionImages").SetActive(false);
        GameObject.Find("TwinButton").SetActive(false);
        GameObject.Find("BusButton").SetActive(false);

    }

    public void clickConfirm()
    {
        _numberOfStops = int.Parse(NumberOfStops.text);
        _busVelocity = float.Parse(busVelocity.text);
        _numberOfSpawns = int.Parse(NumberOfSpawns.text);
        _numberOfDespawns = int.Parse(NumberOfDespawns.text);
        _birds = int.Parse(NumberOfBirds.text);
        _trees = int.Parse(NumberOfTrees.text);
        SceneManager.LoadScene("BusBackground");
    }

    public void backToMenu()
    {
        justLoaded = true;
    }
}
