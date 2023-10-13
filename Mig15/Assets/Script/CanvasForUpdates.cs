using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasForUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealseText;
    [SerializeField] TextMeshProUGUI DamageText;
    [SerializeField] TextMeshProUGUI SpeedReloadText;
    [SerializeField] TextMeshProUGUI MoneyText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealseText.text = Progress.Instance.PlayerInfo.MaxHP.ToString();
        DamageText.text = Progress.Instance.PlayerInfo.Damage.ToString();
        SpeedReloadText.text = Progress.Instance.PlayerInfo.TimeBetwinShots.ToString();
        MoneyText.text = Progress.Instance.PlayerInfo.Coins.ToString();
    }

    public void HealseUpdate()
    {
        if(Progress.Instance.PlayerInfo.Coins > 5)
        {
            Progress.Instance.PlayerInfo.Coins -= 5;
            Progress.Instance.PlayerInfo.MaxHP += 1;
            Progress.Instance.SaveProgres();
        }
    }

    public void DamageUpdate()
    {
        if (Progress.Instance.PlayerInfo.Coins > 5)
        {
            Progress.Instance.PlayerInfo.Coins -= 5;
            Progress.Instance.PlayerInfo.Damage += 1;
            Progress.Instance.SaveProgres();
        }
    }

    public void SpeedReloadUpdate()
    {
        if (Progress.Instance.PlayerInfo.Coins > 5)
        {
            Progress.Instance.PlayerInfo.Coins -= 5;
            Progress.Instance.PlayerInfo.TimeBetwinShots -= 0.1f;
            Progress.Instance.SaveProgres();
        }
    }
}
