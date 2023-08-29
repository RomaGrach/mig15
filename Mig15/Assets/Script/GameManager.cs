using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startMenu;
    [SerializeField] TextMeshProUGUI _LevelText;
    [SerializeField] GameObject _finishWindow;
    [SerializeField] GameObject _finishWindowGood;
    [SerializeField] GameObject _finishWindowBad;
    public bool win = false;
    //[SerializeField] CoinManager _coinManager;
    // Start is called before the first frame update
    void Start()
    {
        _LevelText.text = SceneManager.GetActiveScene().name;
        _startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        FindObjectOfType<generatorEnemi>().Play();
        _startMenu.SetActive(false);

        //FindObjectOfType<PlayerBehaviour>().Play();
    }
    public void ShowFinishWindowBadEnd()
    {
        _finishWindow.SetActive(true);
        _finishWindowBad.SetActive(true);
        win = false;
    }
    public void ShowFinishWindowGoodEnd()
    {
        _finishWindow.SetActive(true);
        _finishWindowGood.SetActive(true);
        win = true;
    }
    public void NextLevel()
    {
        if (win)
        {
            int next = SceneManager.GetActiveScene().buildIndex + 1;
            if (next < SceneManager.sceneCountInBuildSettings)
            {
                //_coinManager.SaveToProgress();
                //Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;
                //Progress.Instance.Save();
                SceneManager.LoadScene(next);
            }
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
