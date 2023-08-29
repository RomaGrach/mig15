using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generatorEnemi : MonoBehaviour
{
    public List<GameObject> objectPrefabs;
    public float pozitionX = 5;
    public float pozitionY = 5;
    public float pozitionZ = 5;
    public float limOfEnemyNomber = 5;
    public float timeBetwinEnemi = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Play()
    {
        GenerateEnemi();
    }

    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        GenerateEnemi();
    }
    private void GenerateRandomObject()
    {
            if (objectPrefabs.Count > 0)
            {
                int randomIndex = Random.Range(0, objectPrefabs.Count); // Выбор случайного индекса
                int randomPosition = Random.Range(-50, 50);
                GameObject selectedPrefab = objectPrefabs[randomIndex]; // Выбор случайного префаба
                Instantiate(selectedPrefab, new Vector3(randomPosition, 120, 200), Quaternion.identity);
            }
    }
    private void GenerateEnemi()
    {
        if (limOfEnemyNomber > 0)
        {
            GenerateRandomObject();
            limOfEnemyNomber -= 1;
            StartCoroutine(Create3dObjects(timeBetwinEnemi));
        }
        else
        {
            FindObjectOfType<GameManager>().ShowFinishWindowGoodEnd();
        }
    }
}
