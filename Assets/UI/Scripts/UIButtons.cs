using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void playGame()
    {
        //load whatever scene is the main game
        Debug.Log("Play Game");
    }

    public void quitToOS()
    {
        Application.Quit();
    }

    public void quitToMenu()
    {
        //load main menu scene
        Debug.Log("Load Main Menu");
    }

}
