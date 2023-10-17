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
    [SerializeField] float HealthIncrease = 0.05f;
    [SerializeField] float DamageIncrease = 0.05f;
    [SerializeField] float ReloadIncrease = 0.05f;
    [SerializeField] float Inflation = 0.1f;
    [SerializeField] int StartPrice = 5;
    private float Hinf = 1.0f;
    private float Dinf = 1.0f;
    private float Rinf = 1.0f;
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
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Hinf);
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            Progress.Instance.PlayerInfo.MaxHP *= 1 + HealthIncrease;
            Progress.Instance.SaveProgres();
            Hinf += 1f;
        }
    }

    public void DamageUpdate()
    {
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Dinf);
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            Progress.Instance.PlayerInfo.Damage *= 1 + DamageIncrease;
            Progress.Instance.SaveProgres();
            Dinf += 1f;

        }
    }

    public void SpeedReloadUpdate()
    {
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Rinf);
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            float shotSpeed = Progress.Instance.PlayerInfo.TimeBetwinShots * (ReloadIncrease);
            Progress.Instance.PlayerInfo.TimeBetwinShots -= shotSpeed;
            Progress.Instance.SaveProgres();
            Rinf += 1f;
        }
    }
}
