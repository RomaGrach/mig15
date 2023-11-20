using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coins = 5;
    public int Killed = 0;
    public int Flight = 0;
    public float MaxHP = 5;
    public float Damage = 2;
    public float TimeBetwinShots = 0.5f;
    public float TimeBetwinShots37 = 2f;
    public int Level = 0;
    public float Hprice = 5;
    public float Dprice = 5;
    public float Sprice = 5;
}

public class Progress : MonoBehaviour
{
    public static Progress Instance;
    public PlayerInfo PlayerInfo;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            DownloadProgress();
        }
        else
        {
            Destroy(gameObject);
        }
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
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        PlayerPrefs.SetString("ProgresSave", jsonString);
    }
    public void DownloadProgress()
    {
        if (PlayerPrefs.HasKey("ProgresSave"))
        {
            string jsonString = PlayerPrefs.GetString("ProgresSave");
            PlayerInfo = JsonUtility.FromJson<PlayerInfo>(jsonString);
        }
    }

    public void resetProgress()
    {
        PlayerInfo = new PlayerInfo();
        SaveProgres();
    }


}
