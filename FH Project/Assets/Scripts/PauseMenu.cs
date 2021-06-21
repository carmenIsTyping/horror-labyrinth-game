using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject crossHair;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        crossHair.SetActive(true);
        Time.timeScale = 1f;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        crossHair.SetActive(false);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
