using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int killedEnemies = 0;
    public int endMoney = 0;
    [SerializeField] TextMeshProUGUI ScoreText;

    [SerializeField] TextMeshProUGUI ScoreTextEnd;
    [SerializeField] TextMeshProUGUI MoneyTextEnd;
    [SerializeField] GameObject CanvasFinish;
    public bool flag = true;

    private void Update()
    {
        if (ScoreText != null)
        {
            // Обновите текстовое поле с текущим количеством убитых врагов
            ScoreText.text = " " + killedEnemies.ToString();
            ScoreTextEnd.text =  killedEnemies.ToString();
        }
        if (flag)
        {
            if (CanvasFinish.activeSelf == true) // проверка на то что объект активен
            {
                endMoney = (int)(killedEnemies * 1.2); // endMoney должнобыть целое число
                MoneyTextEnd.text = "+" + endMoney.ToString();
                Progress.Instance.PlayerInfo.Coins += endMoney;
                Progress.Instance.PlayerInfo.Killed += killedEnemies;
                Progress.Instance.PlayerInfo.Flight += 1;
                Progress.Instance.SaveProgres();
                flag = false;
            }
        }
    }
}
