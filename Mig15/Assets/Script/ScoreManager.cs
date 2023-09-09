using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int killedEnemies = 0;
    [SerializeField] TextMeshProUGUI ScoreText;


    private void Update()
    {
        if (ScoreText != null)
        {
            // Обновите текстовое поле с текущим количеством убитых врагов
            ScoreText.text = "Убито врагов: " + killedEnemies.ToString();
        }
    }
}
