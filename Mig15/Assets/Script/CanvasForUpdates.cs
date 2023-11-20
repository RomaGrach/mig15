using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasForUpdates : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealseText;
    [SerializeField] TextMeshProUGUI ButtonHealthText;
    [SerializeField] TextMeshProUGUI DamageText;
    [SerializeField] TextMeshProUGUI ButtonDamageText;
    [SerializeField] TextMeshProUGUI SpeedReloadText;
    [SerializeField] TextMeshProUGUI ButtonSpeedReloadText;
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
    float RoundUp(float x, float degree = 100f)
    {
        int y = Mathf.RoundToInt(x * degree);
        Debug.Log(y);
        x = y / degree;
        Debug.Log(x);
        return x;
    }

    // Update is called once per frame
    void Update()
    {
        HealseText.text = Progress.Instance.PlayerInfo.MaxHP.ToString();
        ButtonHealthText.text = "Улучшить за " + Progress.Instance.PlayerInfo.Hprice.ToString() + " монет";
        DamageText.text = Progress.Instance.PlayerInfo.Damage.ToString();
        ButtonDamageText.text = "Улучшить за " + Progress.Instance.PlayerInfo.Dprice.ToString() + " монет";
        SpeedReloadText.text = Progress.Instance.PlayerInfo.TimeBetwinShots.ToString();
        ButtonSpeedReloadText.text = "Улучшить за " + Progress.Instance.PlayerInfo.Sprice.ToString() + " монет";
        MoneyText.text = Progress.Instance.PlayerInfo.Coins.ToString();
    }

    public void HealseUpdate()
    {
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Hinf);
        Progress.Instance.PlayerInfo.Hprice = price;
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            Progress.Instance.PlayerInfo.MaxHP *= 1 + HealthIncrease;
            Progress.Instance.PlayerInfo.MaxHP = RoundUp(Progress.Instance.PlayerInfo.MaxHP);
            Progress.Instance.SaveProgres();
            Hinf += 1f;
        }
    }

    public void DamageUpdate()
    {
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Dinf);
        Progress.Instance.PlayerInfo.Dprice = price;
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            Progress.Instance.PlayerInfo.Damage *= RoundUp(1 + DamageIncrease);
            Progress.Instance.PlayerInfo.Damage = RoundUp(Progress.Instance.PlayerInfo.Damage);
            Progress.Instance.SaveProgres();
            Dinf += 1f;

        }
    }

    public void SpeedReloadUpdate()
    {
        int price = (StartPrice - 1) + (int)Mathf.Exp(Inflation * Rinf);
        Progress.Instance.PlayerInfo.Sprice = price;
        if (Progress.Instance.PlayerInfo.Coins >= price)
        {
            Progress.Instance.PlayerInfo.Coins -= price;
            float shotSpeed = Progress.Instance.PlayerInfo.TimeBetwinShots * (ReloadIncrease);
            Progress.Instance.PlayerInfo.TimeBetwinShots -= shotSpeed;
            Progress.Instance.PlayerInfo.TimeBetwinShots = RoundUp(Progress.Instance.PlayerInfo.TimeBetwinShots, 1000f);
            Progress.Instance.SaveProgres();
            Rinf += 1f;
        }
    }
}
