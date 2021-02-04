using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettings : MonoBehaviour
{

    public GameObject title;
    public GameObject mainMenu;
    public GameObject settings;

    void Start()
    {
        title.SetActive(true);
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void openSettings()
    {
        title.SetActive(false);
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void backToMenu()
    {
        title.SetActive(true);
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }
}
