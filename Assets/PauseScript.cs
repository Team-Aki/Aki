using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject panel;
    private bool gameIsPaused;

    void Start()
    {
        panel.SetActive(false);
        gameIsPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }

            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
