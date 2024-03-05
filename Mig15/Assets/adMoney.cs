using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class adMoney : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = 15;
    void Start()
    {
        YandexGame.RewardVideoEvent += Reward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reward(int id)
    {
        if (id == 11101)
        {
            Progress.Instance.PlayerInfo.Coins += money;
            Progress.Instance.SaveProgres();
        }

    }

    public void OnClickAdd()
    {
        YandexGame.RewVideoShow(11101);

    }
}
