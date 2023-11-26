using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RepositoryOfStageOptions
{
    // первый элемент тип волны
    // второй элемент длина волны
    // время между генирациями
    // последующие элименты враги
    public float[][] Options = new float[][] {
    new float[] { 0, 20, 1, 0,0,0,0,0,0,0,0 },
    new float[] { 1, 20, 5, 0,0,0,0,0,0,0,0 },
    new float[] { 0, 30, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 },
    new float[] { 0, 10, 0.1f, 0,0,0 },
    new float[] { 1, 20, 0.1f, 0, 0, 0, 0, 0, 0, 0, 0 } // Добавлена запятая
};

}

public class StageOptions : MonoBehaviour
{
    public static StageOptions Instance;
    public RepositoryOfStageOptions RepositoryOfStageOptions;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            
            DontDestroyOnLoad(gameObject);
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        for (int i = 0; i < StageOptions.Instance.RepositoryOfStageOptions.Options.Length; i++)
        {
            string rowContent = "Row " + i + ": ";
            for (int j = 0; j < StageOptions.Instance.RepositoryOfStageOptions.Options[i].Length; j++)
            {
                rowContent += StageOptions.Instance.RepositoryOfStageOptions.Options[i][j] + " ";
            }
            Debug.Log(rowContent);
        }
    }

}
