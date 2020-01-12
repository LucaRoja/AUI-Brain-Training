using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    private static GameObject _restartButton;
    void Start()
    {
        _restartButton = GameObject.Find("Restart");
        _restartButton.SetActive(false);
    }

    public static void gameOver()
    {
        _restartButton.SetActive(true);
    }

    public void onClickRestart()
    {
        SceneManager.LoadScene("TwinColors");
    }
}
