using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class BattleStages
{
    public int[] Stage1;
    public int[] Stage2;
    public int[] Stage3;
    public int[] Stage4;
    public int[] Stage5;
    public int[] Stage6;
    public int[] Stage7;
    public int[] Stage8;
    public int[] Stage9;
    public int[] Stage10;
    public int[] Stage11;
}

public class GeneratorEnemiModified : MonoBehaviour
{
    public BattleStages BattleStages;
    public int NowNumberOfStages;
    public float[] TipeOfStage; // 0-таймер 1-убить Всех Врагов
    public int[][] BS;
    public List<GameObject> EnemisPrefabs;
    public List<Transform> GenerationPositions;
    public float[] TimeBetweenGenerations;
    public float[] TimeBetweenStages;
    public bool GenerateStages = true;


    private int enemisOnScene;
    // Start is called before the first frame update
    void Start()
    {
        TipeOfStage = new float[NowNumberOfStages];
        TimeBetweenGenerations = new float[NowNumberOfStages];
        TimeBetweenStages = new float[NowNumberOfStages];
        BS = new int[NowNumberOfStages][];
        if (GenerateStages)
        {
            StartGenerations();
        }else
        {
            TransferBattleStages(BattleStages);
        }
        GlobalEventManager.OnEnemyKilled.AddListener(EnemiKildForTipe1);
    }
    public void StartGenerations()
    {

        for (int i = 0; i < NowNumberOfStages; i++)
        {
            int RS = Random.Range(0, StageOptions.Instance.RepositoryOfStageOptions.Options.Length);
            
            TipeOfStage[i] = StageOptions.Instance.RepositoryOfStageOptions.Options[RS][0];
            TimeBetweenStages[i] = StageOptions.Instance.RepositoryOfStageOptions.Options[RS][1];
            TimeBetweenGenerations[i] = StageOptions.Instance.RepositoryOfStageOptions.Options[RS][2];
            BS[i] = new int[StageOptions.Instance.RepositoryOfStageOptions.Options[RS].Length - 3];
            Debug.Log(string.Join(", ", StageOptions.Instance.RepositoryOfStageOptions.Options[RS].Select(element => element.ToString()).ToArray()));
            for (int j = 0; j < BS[i].Length; j++)
            {
                BS[i][j] = (int)StageOptions.Instance.RepositoryOfStageOptions.Options[RS][j + 3];
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        StartCoroutine(GenerateEnemi());
    }
    private IEnumerator GenerateEnemi()
    {
        for (int i = 0; i < NowNumberOfStages; i++)
        {
            if (TipeOfStage[i] == 0) { 
                for (int j = 0; j < BS[i].Length; j++)
                {
                    if (BS[i][j] == 1)
                    {
                        GenerateObject(EnemisPrefabs[BS[i][j]], GenerationPositions[1], false);
                    }
                    else if (BS[i][j] == 0)
                    {
                        GenerateObject(EnemisPrefabs[BS[i][j]], GenerationPositions[0],true);
                    }

                    yield return new WaitForSeconds(TimeBetweenGenerations[i]);// таймер TimeBetweenGenerations
                }
                yield return new WaitForSeconds(TimeBetweenStages[i]);// таймер TimeBetweenStages
            }
            else if (TipeOfStage[i] == 1)
            {
                enemisOnScene = BS[i].Length;
                for (int j = 0; j < BS[i].Length; j++)
                {
                    if (BS[i][j] == 1)
                    {
                        GenerateObject(EnemisPrefabs[BS[i][j]], GenerationPositions[1], false);
                    }
                    else if (BS[i][j] == 0)
                    {
                        GenerateObject(EnemisPrefabs[BS[i][j]], GenerationPositions[0], true);
                    }

                    yield return new WaitForSeconds(TimeBetweenGenerations[i]);// таймер TimeBetweenGenerations
                }
                while (enemisOnScene > 0)
                {
                    yield return null; // Пауза на один кадр
                }
            }

        }
        FindObjectOfType<GameManager>().ChekEnemy();
    }
    private void GenerateObject(GameObject Enemi, Transform transform, bool random)
    {
        int randomPosition = Random.Range(-50, 50);
        if (random) {
            Instantiate(Enemi, new Vector3(randomPosition, 120, 200), Quaternion.identity);
        }
        else
        {
            Instantiate(Enemi, transform.position, Quaternion.identity);
        }
        
    }
    public void EnemiKildForTipe1()
    {
        enemisOnScene -= 1;
    }
    public void TransferBattleStages(BattleStages battleStages)
    {
        BS = new int[][]
        {
            battleStages.Stage1,
            battleStages.Stage2,
            battleStages.Stage3,
            battleStages.Stage4,
            battleStages.Stage5,
            battleStages.Stage6,
            battleStages.Stage7,
            battleStages.Stage8,
            battleStages.Stage9,
            battleStages.Stage10,
            battleStages.Stage11
        };
    }
}
