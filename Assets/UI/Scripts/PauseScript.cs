using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseFrame;
    public GameObject settingsFrame;
    public GameObject panel;

    private bool gameIsPaused;

    void Start()
    {
        pauseFrame.SetActive(false);
        settingsFrame.SetActive(false);
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
        pauseFrame.SetActive(false);
        settingsFrame.SetActive(false);
        panel.SetActive(false);

        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void pause()
    {
        pauseFrame.SetActive(true);
        settingsFrame.SetActive(false);
        panel.SetActive(true);

        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void settings()
    {
        pauseFrame.SetActive(false);
        settingsFrame.SetActive(true);
    }
}
