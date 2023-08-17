using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genetator : MonoBehaviour
{
    public float SpavnTime = 5f;
    public GameObject obj;
    public List<GameObject> objectPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        GenerateRandomObject();
        StartCoroutine(Create3dObjects(10f));
    }

    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        GenerateRandomObject();
    }
    private void GenerateRandomObject()
    {
        if (objectPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, objectPrefabs.Count); // Выбор случайного индекса
            GameObject selectedPrefab = objectPrefabs[randomIndex]; // Выбор случайного префаба
            Instantiate(selectedPrefab, transform.position, Quaternion.identity);
        }
        StartCoroutine(Create3dObjects(10f));
    }
}
