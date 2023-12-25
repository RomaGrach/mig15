using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Accessibility;
using static UnityEngine.Rendering.DebugUI;

[System.Serializable]
public class PlayerInfo
{
    public int Coins = 5;
    public int Killed = 0;
    public int Flight = 0;
    public float MaxHP = 5;
    public float Damage = 2;
    public float Armor = 1;
    public float TimeBetwinShots = 0.5f;
    public float TimeBetwinShots37 = 2f;
    public int Level = 0;
    public float Hprice = 5;
    public float Dprice = 5;
    public float Aprice = 5;
    public float Sprice = 5;
    public float S23price = 5;
    public float S37price = 5;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public static Progress Instance;
    public PlayerInfo PlayerInfo;
    public bool Yandex = false;
    public bool Test = false;
    public bool PlayerDidSomething = false;
    public bool PlayerFirstGame = true;

    private void Awake()
    {
        Yandex = false;
#if UNITY_WEBGL
        Yandex = true;
        Debug.Log("Unity WEBGL");
#endif
#if UNITY_EDITOR
        Yandex = false;
        Debug.Log("Unity Editor");
#endif
        
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            //StartCoroutine(WaitTime());
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2f);
        Test = true;
        Debug.Log("WaitTime" + PlayerInfo.Coins);
        DownloadProgress();
        Debug.Log("WaitTime" + PlayerInfo.Coins);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveProgres()
    {
        Debug.Log("SaveProgres" + Yandex);
        if (Yandex)
        {
            SaveProgresYandex();
        }
        else
        {
            SaveProgresPlayerPrefs();
        }
        Debug.Log(PlayerInfo);
    }


    public void DownloadProgress()
    {
        Debug.Log("DownloadProgress" + Yandex);
        if (Yandex)
        {
            LoadExtern();
        }
        else
        {
            DownloadProgressPlayerPrefs();
        }
        Debug.Log(PlayerInfo);
    }

    public void DownloadProgressPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("ProgresSave"))
        {
            string jsonString = PlayerPrefs.GetString("ProgresSave");
            PlayerInfo = JsonUtility.FromJson<PlayerInfo>(jsonString);
        }
    }

    public void SaveProgresPlayerPrefs()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        PlayerPrefs.SetString("ProgresSave", jsonString);
    }

    public void resetProgress()
    {
        PlayerInfo = new PlayerInfo();
        SaveProgres();
    }

    public void SaveProgresYandex()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfoYandex(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }

}
