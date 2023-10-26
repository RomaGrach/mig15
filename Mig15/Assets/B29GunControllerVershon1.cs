using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunElements1 // массив турелей  первый элемент каждого массива объект горизонтального вращения (на нем раньше находился скрипт testRotationGun2Clear), второй элемент каждого массива объект вертикального наведения (VerticalDrives)
{
    public GameObject[] GunForB29FrontUp;
    public GameObject[] GunForB29FrontDown;
    public GameObject[] GunForB29BackDown;
    public GameObject[] GunForB29BackUp;
    public GameObject[] GunForB29Tail;
}



public class B29GunControllerVershon1 : MonoBehaviour
{
    public GunElements1 gunElements;
    public float rotationSpeed = 3f; // Скорость вращения (градусы в секунду)
    public float maxRotationAngle = 35f; // Максимальный угол наклона ствола вверх и вниз

    private Transform player; // Ссылка на объект игрока
    private Transform[] horizontalGunTransforms; // Массив компонентов трансформ для горизонтальных стволов
    private Transform[] verticalDrivesTransforms; // Массив компонентов трансформ для вертикальных приводов

    private void Start()
    {
        player = FindObjectOfType<PlayerMarker>().transform;

        // Инициализируем массивы трансформов для горизонтальных и вертикальных турелей
        horizontalGunTransforms = new Transform[]
        {
            gunElements.GunForB29FrontUp[0].transform,
            gunElements.GunForB29FrontDown[0].transform,
            gunElements.GunForB29BackDown[0].transform,
            gunElements.GunForB29BackUp[0].transform,
            gunElements.GunForB29Tail[0].transform
        };

        verticalDrivesTransforms = new Transform[]
        {
            gunElements.GunForB29FrontUp[1].transform,
            gunElements.GunForB29FrontDown[1].transform,
            gunElements.GunForB29BackDown[1].transform,
            gunElements.GunForB29BackUp[1].transform,
            gunElements.GunForB29Tail[1].transform
        };
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }

        // Горизонтальное вращение для каждой турели
        for (int i = 0; i < horizontalGunTransforms.Length; i++)
        {
            Transform horizontalGunTransform = horizontalGunTransforms[i];
            Vector3 directionToPlayer = player.position - horizontalGunTransform.position;
            Vector3 projectedXZ = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);
            float angle = Vector3.Angle(horizontalGunTransform.forward, projectedXZ);

            if (angle > 0.1f)
            {
                Vector3 rotationAxis = Vector3.Cross(horizontalGunTransform.forward, projectedXZ);
                float rotationDirection = Vector3.Dot(rotationAxis, horizontalGunTransform.up) > 0 ? 1 : -1;
                horizontalGunTransform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
            }
        }

        // Вертикальное вращение для каждой турели
        for (int i = 0; i < verticalDrivesTransforms.Length; i++)
        {
            Transform verticalDrivesTransform = verticalDrivesTransforms[i];
            Vector3 directionToPlayerVDT = player.position - verticalDrivesTransform.position;
            Vector3 localDirection = verticalDrivesTransform.InverseTransformDirection(directionToPlayerVDT);
            Vector3 projectedYZ = Vector3.ProjectOnPlane(localDirection, Vector3.right);
            float vertAngle = Vector3.Angle(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
            float limitAngle = Vector3.Angle(verticalDrivesTransform.up, verticalDrivesTransform.TransformDirection(projectedYZ));

            if (limitAngle < maxRotationAngle && vertAngle > 0.1f)
            {
                Vector3 vertikalRotationAxis = Vector3.Cross(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
                float rotationDirectionScalyrnoeProizvedenieVert = Vector3.Dot(vertikalRotationAxis, verticalDrivesTransform.right);

                float rotationDirectionVert = rotationDirectionScalyrnoeProizvedenieVert > 0 ? 1 : -1;
                verticalDrivesTransform.Rotate(Vector3.right * rotationSpeed * rotationDirectionVert * Time.deltaTime);
            }
        }
    }
}
