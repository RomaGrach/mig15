using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

[System.Serializable]
public class GunElements2 // массив турелей  первый элемент каждого массива объект горизонтального вращения (на нем раньше находился скрипт testRotationGun2Clear), второй элемент каждого массива объект вертикального наведения (VerticalDrives)
{
    public GameObject[] GunForB29FrontUp;
    public GameObject[] GunForB29FrontDown;
    public GameObject[] GunForB29BackDown;
    public GameObject[] GunForB29BackUp;
    public GameObject[] GunForB29Tail;
}


public class B29GunControllerVershon2 : MonoBehaviour
{
    public GunElements2 gunElements;
    public float rotationSpeed = 3f; // Скорость вращения (градусы в секунду)
    public float maxRotationAngle = 35f; // Максимальный угол наклона ствола вверх и вниз
    private Transform player; // Ссылка на объект игрока

    Transform[][] allGunTransforms;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMarker>().transform;

        // Создаем двумерный массив для хранения элементов в формате Transform
        allGunTransforms = new Transform[][]
        {
        ConvertToTransformArray(gunElements.GunForB29FrontUp),
        ConvertToTransformArray(gunElements.GunForB29FrontDown),
        ConvertToTransformArray(gunElements.GunForB29BackDown),
        ConvertToTransformArray(gunElements.GunForB29BackUp),
        ConvertToTransformArray(gunElements.GunForB29Tail)
        };

        

    }

    private Transform[] ConvertToTransformArray(GameObject[] gameObjects)
    {
        Transform[] transforms = new Transform[gameObjects.Length];
        for (int i = 0; i < gameObjects.Length; i++)
        {
            transforms[i] = gameObjects[i].transform;
        }
        return transforms;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }

        for (int i = 0; i < allGunTransforms.Length; i++)
        {
            Controlguns(allGunTransforms[i]);
        }

    }

    void Controlguns(Transform[] ElementList)
    {
        Transform HorizontalDrivesTransform = ElementList[0];
        Transform verticalDrivesTransform = ElementList[1];
        float rotationDirection;
        float rotationDirectionVert;

        //работа горизонта

        Vector3 directionToPlayer = player.position - HorizontalDrivesTransform.position; // вектор указывающий на игрока от центра башни

        Vector3 projectedXZ = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);
        Debug.DrawRay(HorizontalDrivesTransform.position, projectedXZ, Color.green);

        float angle = Vector3.Angle(HorizontalDrivesTransform.forward, projectedXZ);

        if (angle > 0.1f)
        {
            // Находим ось вращения
            Vector3 rotationAxis = Vector3.Cross(HorizontalDrivesTransform.forward, projectedXZ); //векторное произведение
            Debug.DrawRay(HorizontalDrivesTransform.position, rotationAxis, Color.black);
            // Определение направления вращения (по или против часовой стрелки)
            float rotationDirectionScalyrnoeProizvedenie = Vector3.Dot(rotationAxis, HorizontalDrivesTransform.up); // скалярное произведение
            if (rotationDirectionScalyrnoeProizvedenie > 0)
            {
                rotationDirection = 1;
            }
            else
            {
                rotationDirection = -1;
            }


            // Вращаем объект вокруг этой оси с заданной скоростью и направлением
            HorizontalDrivesTransform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
        }



        //работа горизонта

        //работа вертикальная

        Vector3 directionToPlayerVDT = player.position - verticalDrivesTransform.position;

        // Получите локальный вектор в системе координат объекта VerticalDrives
        Vector3 localDirection = verticalDrivesTransform.InverseTransformDirection(directionToPlayerVDT);


        Vector3 projectedYZ = Vector3.ProjectOnPlane(localDirection, Vector3.right);
        Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.TransformDirection(projectedYZ), Color.blue);

        float VertAngle = Vector3.Angle(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        float LimitAngle = Vector3.Angle(HorizontalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        if (LimitAngle < 35f)
        {

            if (VertAngle > 0.1f)
            {
                // Находим ось вращения
                Vector3 VertikalRotationAxis = Vector3.Cross(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ)); //векторное произведение
                Debug.DrawRay(verticalDrivesTransform.position, VertikalRotationAxis, Color.black);
                // Определение направления вращения (по или против часовой стрелки)
                float rotationDirectionScalyrnoeProizvedenieVert = Vector3.Dot(VertikalRotationAxis, HorizontalDrivesTransform.right); // скалярное произведение
                Debug.DrawRay(verticalDrivesTransform.position, HorizontalDrivesTransform.forward, Color.red);
                if (rotationDirectionScalyrnoeProizvedenieVert > 0)
                {
                    rotationDirectionVert = 1;
                }
                else
                {
                    rotationDirectionVert = -1;
                }


                // Вращаем объект вокруг этой оси с заданной скоростью и направлением
                verticalDrivesTransform.Rotate(Vector3.right * rotationSpeed * rotationDirectionVert * Time.deltaTime);
            }
        }



        //работа вертикальная


    }
}
