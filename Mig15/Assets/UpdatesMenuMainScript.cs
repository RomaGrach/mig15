using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatesMenuMainScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TextDescription;
    [SerializeField] TextMeshProUGUI TextMoney;
    float priseIndex = 1.5f;
    float UpdateIndex = 1.5f;
    int NowUpdate = -1;

    string[] description = new string[]
    {
        "Увеличивает сдоровье","Увеличивает урон","Увеличивает броню","Увеличивает скорострельность 23мм пушки"
        ,"Увеличивает скорострельность 37мм пушки"
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMoney.text = Progress.Instance.PlayerInfo.Coins.ToString();
    }
    
    public void SetImprovement(int a)
    {
        NowUpdate = a;
        setDescription(NowUpdate);
    }

    public void improve()
    {
        if (NowUpdate>=0)
        {
            improveInside();
            setDescription(NowUpdate);
            Progress.Instance.SaveProgres();
        }
    }

    void improveInside()
    {
        if (NowUpdate == 0)
        {
            if(Progress.Instance.PlayerInfo.Coins >= Progress.Instance.PlayerInfo.Hprice * priseIndex)
            {
                Progress.Instance.PlayerInfo.Hprice *= priseIndex;
                Progress.Instance.PlayerInfo.MaxHP *= UpdateIndex;
                Debug.Log((int)(Progress.Instance.PlayerInfo.Hprice * priseIndex));
                Progress.Instance.PlayerInfo.Coins -= (int)(Progress.Instance.PlayerInfo.Hprice * priseIndex);
            }
            
        }
        else if (NowUpdate == 1)
        {
            if (Progress.Instance.PlayerInfo.Coins >= Progress.Instance.PlayerInfo.Dprice * priseIndex)
            {
                Progress.Instance.PlayerInfo.Dprice *= priseIndex;
                Progress.Instance.PlayerInfo.Damage *= UpdateIndex;
                Progress.Instance.PlayerInfo.Coins -= (int)(Progress.Instance.PlayerInfo.Dprice * priseIndex);
            }
        }
        else if (NowUpdate == 2)
        {
            if (Progress.Instance.PlayerInfo.Coins >= Progress.Instance.PlayerInfo.Aprice * priseIndex)
            {
                Progress.Instance.PlayerInfo.Aprice *= priseIndex;
                Progress.Instance.PlayerInfo.Armor *= UpdateIndex;
                Progress.Instance.PlayerInfo.Coins -= (int)(Progress.Instance.PlayerInfo.Aprice * priseIndex);
            }
        }
        else if (NowUpdate == 3)
        {
            if (Progress.Instance.PlayerInfo.Coins >= Progress.Instance.PlayerInfo.S23price * priseIndex)
            {
                Progress.Instance.PlayerInfo.S23price *= priseIndex;
                Progress.Instance.PlayerInfo.TimeBetwinShots *= (UpdateIndex-1);
                Progress.Instance.PlayerInfo.Coins -= (int)(Progress.Instance.PlayerInfo.S23price * priseIndex);
            }
        }
        else if (NowUpdate == 4)
        {
            if (Progress.Instance.PlayerInfo.Coins >= Progress.Instance.PlayerInfo.S37price * priseIndex)
            {
                Progress.Instance.PlayerInfo.S37price *= priseIndex;
                Progress.Instance.PlayerInfo.TimeBetwinShots37 *= (UpdateIndex - 1);
                Progress.Instance.PlayerInfo.Coins -= (int)(Progress.Instance.PlayerInfo.S37price * priseIndex);
            }
        }
    }

    public void setDescription(int a)
    {

        string prise = "";
        string value = "";

        if (a == 0){
            prise = (priseIndex * Progress.Instance.PlayerInfo.Hprice).ToString();
            value = (Progress.Instance.PlayerInfo.MaxHP).ToString();
            Debug.Log(Progress.Instance.PlayerInfo.Hprice+"_____");
        }
        else if (a == 1){
            prise = (priseIndex * Progress.Instance.PlayerInfo.Dprice).ToString();
            value = (Progress.Instance.PlayerInfo.Damage).ToString();
        }
        else if(a == 2){
            prise = (priseIndex * Progress.Instance.PlayerInfo.Aprice).ToString();
            value = (Progress.Instance.PlayerInfo.Armor).ToString();
        }
        else if(a == 3){
            prise = (priseIndex * Progress.Instance.PlayerInfo.S23price).ToString();
            value = (Progress.Instance.PlayerInfo.TimeBetwinShots).ToString();
        }
        else if(a == 4){
            prise = (priseIndex * Progress.Instance.PlayerInfo.S37price).ToString();
            value = (Progress.Instance.PlayerInfo.TimeBetwinShots37).ToString();
        }
        TextDescription.text = "Стоимость улучшения: " + prise + "\n"+"Текущие значение: "+ value + "\n" + description[a];
    }
    
}
