using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public void PlayGame()
    {
        SceneManager.LoadScene("New Scene");
    }
    public void ExitGame()
    {
        Debug.Log("off");
        Application.Quit();
    }
    private void Start()
    {
        if (Progress.Instance.PlayerDidSomething)
        {
            Progress.Instance.PlayAdv();
        }
    }
    public void ThePlayerDidSomething()
    {
        
        if (!Progress.Instance.PlayerDidSomething)
        {
            //Progress.Instance.DownloadProgress();
            Progress.Instance.PlayerDidSomething = true;
        }
        
    }

}
