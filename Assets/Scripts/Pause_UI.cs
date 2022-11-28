using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_UI : MonoBehaviour
{

    public static bool IsPaused;
    //public GameObject pauseMenuUI;
    //public GameObject pause_ui;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        IsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        IsPaused = false;
    }

    public void PauseGame()
    {
        //pauseMenuUI.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title_Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
