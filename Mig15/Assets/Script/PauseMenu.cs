using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public Comments[] tips;
    [SerializeField] TextMeshProUGUI Comment;
    
    //public Text comments2;
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            if (GameIsPaused)
            {
                Debug.Log("1242345346456");
                
                Button_back();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
    }
    public void Button_back()
    {
        if (Progress.Instance.PlayerInfo.Desktop)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        CommentsAct();
        
    }
    void CommentsAct()
    {
        int i = Random.Range(0, tips.Length-1);
        Debug.Log(tips[i].Ru);
        //comments_txt.text = "25345634t6345";
        if (Comment) 
        {
            Comment.text = tips[i].Ru.ToString();
        }
        else
        {
            Debug.LogError("ВСЕ ПЛОХО");
        }
        
        //comments_txt.text = "25345634t6345";
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
