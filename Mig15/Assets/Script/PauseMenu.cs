using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Button_back();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Button_back()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;
    }
    public void Button_exit()
    {
        Debug.Log("Exit");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
}
