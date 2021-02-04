using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

    public void playGame()
    {
        Time.timeScale = 1;
        //load whatever scene is the main game
        Debug.Log("Play Game");

        SceneManager.LoadScene("MainScene");
    }

    public void quitToOS()
    {
        Application.Quit();
    }

    public void quitToMenu()
    {
        Time.timeScale = 1;
        //load main menu scene
        Debug.Log("Load Main Menu");

        SceneManager.LoadScene("MainMenu");
    }

}
