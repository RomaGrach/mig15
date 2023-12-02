
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorAuxiliaryObject : MonoBehaviour
{
    public float IntervalFrom = 1f; // Интервал между генерациями от
    public float IntervalTo = 1f; // Интервал между генерациями до
    [SerializeField] GameObject[] AuxiliaryObjects; // вспомогательные объекты
    public float GenerationPositionZ = 10; // позиция отсчета по Z для генерации

    // Start is called before the first frame update
    void Start()
    {
        GlobalEventManager.OnStartOfLevel.AddListener(play);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void play()
    {

        StartCoroutine(GenerateAuxiliaryObjects());
    }
    private IEnumerator GenerateAuxiliaryObjects()
    {
        Debug.Log("______________________________________________________");
        float randomInterval = Random.Range(IntervalFrom, IntervalTo);
        int randomAuxiliary = Random.Range(0, AuxiliaryObjects.Length);
        float randomPositionX = Random.Range(-50, 50);
        Instantiate(AuxiliaryObjects[randomAuxiliary], new Vector3(randomPositionX, 100, GenerationPositionZ), Quaternion.identity);

        yield return new WaitForSeconds(randomInterval);
        StartCoroutine(GenerateAuxiliaryObjects());
    }

}
