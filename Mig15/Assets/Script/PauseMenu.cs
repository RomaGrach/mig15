using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Comments[] tips;
    public Text comments_txt;
    //public Text comments2;
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
        CommentsAct();
        Time.timeScale=0f;
        GameIsPaused = true;
    }
    void CommentsAct()
    {
        int i = Random.Range(0, tips.Length);
        comments_txt.text = tips[i].Ru;
        //comments_txt.text = tips[1].Ru;
        //comments_txt.text = tips[2].Ru;
        //comments2.text = tips[1].Ru;

    }
    public void Button_exit()
    {
        Debug.Log("Exit");
        Time.timeScale = 1f;
        //SceneManager.LoadScene("Menu");

    }
}
