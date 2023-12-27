using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnvironmentTypes
{
    public GameObject[] Fields;
    public GameObject[] WinterFields;
    public GameObject[] Village;
    public GameObject[] FallbackOption1;
    public GameObject[] FallbackOption2;
    public GameObject[] FallbackOption3;
    public GameObject[] FallbackOption4;
    public GameObject[] FallbackOption5;
    public GameObject[] FallbackOption6;
}


public class GeneratorEnvironmentModified : MonoBehaviour
{
    public EnvironmentTypes EnvironmentTypes;
    public GameObject[][] ET;
    public GameObject[] DistantLandscapes;
    public float TimeBetweenGenerations = 10f;
    public int TypeOfEnvironment = 0;
    public int TypeOfDistantLandscapes = 0;
    public List<Transform> GenerationPositions;
    public Transform GenerationLandscapePosition;
    public List<Transform> GenerationBasikPositions;
    public bool StopGeneration = false;

    // Start is called before the first frame update
    void Start()
    {
        int a = Random.Range(0, 2) *2;
        Debug.Log(a);
        TypeOfEnvironment = a;
        TransferEnvironmentTypes(EnvironmentTypes);
        StartChangeEnvironment();
        Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        StartCoroutine(GenerateEnvironment());
    }

    public void StartChangeEnvironment()
    {
        Instantiate(DistantLandscapes[TypeOfDistantLandscapes], GenerationLandscapePosition.position, Quaternion.identity);
        for (int i = 0; i < GenerationBasikPositions.Count; i++)
        {
            int randomIndex = Random.Range(0, ET[TypeOfEnvironment].Length); // Выбор случайного индекса
            Instantiate(ET[TypeOfEnvironment][randomIndex], GenerationBasikPositions[i].position, Quaternion.identity);
        }
    }
    private IEnumerator GenerateEnvironment()
    {
        if (!StopGeneration)
        {
            for (int i = 0; i < GenerationPositions.Count; i++)
            {
                int randomIndex = Random.Range(0, ET[TypeOfEnvironment].Length); // Выбор случайного индекса
                Instantiate(ET[TypeOfEnvironment][randomIndex], GenerationPositions[i].position, Quaternion.identity);
            }
            yield return new WaitForSeconds(TimeBetweenGenerations);
            StartCoroutine(GenerateEnvironment());
        }
    }





    public void TransferEnvironmentTypes(EnvironmentTypes EnvironmentTypes)
    {
        ET = new GameObject[][]
        {
            EnvironmentTypes.Fields,
            EnvironmentTypes.WinterFields,
            EnvironmentTypes.Village,
            EnvironmentTypes.FallbackOption1,
            EnvironmentTypes.FallbackOption2,
            EnvironmentTypes.FallbackOption3,
            EnvironmentTypes.FallbackOption4,
            EnvironmentTypes.FallbackOption5,
            EnvironmentTypes.FallbackOption6
        };
    }
}
