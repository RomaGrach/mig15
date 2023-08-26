using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoToPosition : MonoBehaviour
{
    public float pozitionX = 5;
    public float pozitionY = 100.04f;
    public float pozitionZ = 5;
    public float movementSpeed = 2f; // Скорость движения
    public float rotationSpeed = 100f; // Скорость поворота
    float XRand = 5;
    float YRand = 100.04f;
    float ZRand = 5;
    public bool done = false;
    private void Start()
    {
        pozitionX= Random.Range(-2f, 2f);
        pozitionZ = Random.Range(2.7f, 3.5f);
        XRand = RN();
        YRand = RN();
        ZRand = RN();
    }
    private float RN()
    {   // RandomeNamber
        return Random.Range(-1f, 1f);
    }
    private float RN1()
    {   // RandomeNamber
        return Random.Range(0.1f, 1f);
    }
    private void Update()
    {

        if (transform.position != new Vector3(pozitionX, pozitionY, pozitionZ))
        {
            transform.position = transform.position + new Vector3(XRand, YRand, ZRand) * Time.deltaTime * movementSpeed * 0.2f * RN1();
        }
        else
        {
            if (transform.localEulerAngles == Vector3.zero)
            {
                done = true;
            }
        }
            // Вычисляем направление движения
        Vector3 targetDirection = new Vector3(pozitionX - transform.position.x, pozitionY - transform.position.y, pozitionZ - transform.position.z).normalized;

        // Вычисляем ротацию в сторону движения
        Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // Плавно поворачиваем объект в сторону движения
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Выполняем движение к цели
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pozitionX, pozitionY, pozitionZ), step);
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private int RN()
    {   // RandomeNamber
        return Random.Range(-8, 8);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.MoveTowards(transform.position.x, pozitionX, 2f * Time.deltaTime);
        float y = Mathf.MoveTowards(transform.position.y, pozitionY, 2f * Time.deltaTime);
        float z = Mathf.MoveTowards(transform.position.z, pozitionZ, 2f * Time.deltaTime);
        transform.position = new Vector3(x, y, z);

        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, 100f * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, rot, 0);
    }
    *\
    /*
     * float x = Mathf.MoveTowards(transform.position.x, 0, 2f * Time.deltaTime);
        float z = transform.position.z + 3f * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);

        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, 100f * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0, rot, 0);
     */
}
