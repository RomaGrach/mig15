using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    public string objectNameToCheck = "MyEnemy";
    public float checkInterval = 1f; // Интервал проверки в секундах
    //[SerializeField] CoinManager _coinManager;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        if (Progress.Instance.PlayerFirstGame)
        {
            Progress.Instance.PlayerFirstGame = false;
            Progress.Instance.PlayAdv();
            
        }
        
        _LevelText.text = SceneManager.GetActiveScene().name;
        _startMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GlobalEventManager.SendLevelStarted();
        //FindObjectOfType<GeneratorEnemiModified>().Play();
        _startMenu.SetActive(false);

        //FindObjectOfType<PlayerBehaviour>().Play();
    }
    public void ShowFinishWindowBadEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        _finishWindow.SetActive(true);
        _finishWindowBad.SetActive(true);
        win = false;
        
    }
    public void ShowFinishWindowGoodEnd()
    {
        Cursor.lockState = CursorLockMode.None;
        _finishWindow.SetActive(true);
        _finishWindowGood.SetActive(true);
        win = true;
        
    }
    public void NextLevel()
    {
        Cursor.lockState = CursorLockMode.None;
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
    public void GoHomeLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void ChekEnemy()
    {
        StartCoroutine(CheckForObject());
    }
    private IEnumerator CheckForObject()
    {
        while (true)
        {
            // Проверяем наличие объекта на сцене
            GameObject objToCheck = GameObject.Find(objectNameToCheck);

            if (objToCheck != null)
            {
                Debug.Log($"Объект {objectNameToCheck} найден на сцене.");
                // Выполните дополнительные действия, если объект найден
            }
            else
            {
                ShowFinishWindowGoodEnd();
                Debug.LogWarning($"Объект {objectNameToCheck} не найден на сцене.");
                // Выполните другие действия в случае отсутствия объекта
            }

            yield return new WaitForSeconds(checkInterval);
        }
    }
}
