using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotationGun2 : MonoBehaviour
{
    public float rotationSpeed = 3f; // Скорость вращения (градусы в секунду)
    public Transform player; // Ссылка на объект игрока
    [SerializeField] float angleXZ;
    [SerializeField] float angleXY;
    [SerializeField] float angleYZ;
    [SerializeField] float LangleXZ;
    [SerializeField] float LangleXY;
    [SerializeField] float LangleYZ;
    [SerializeField] float angle;

    [SerializeField] float rotationDirection;
    [SerializeField] float rotationDirectionScalyrnoeProizvedenie;

    [SerializeField] Vector3 directionToPlayer;
    [SerializeField] Vector3 projectedXZ;
    [SerializeField] Vector3 projectedYZ;
    [SerializeField] Vector3 localXZ;
    [SerializeField] Vector3 localXY;
    [SerializeField] Vector3 localYZ;
    [SerializeField] Vector3 rotationAxis;


    public GameObject VerticalDrives;
    Transform verticalDrivesTransform;
    [SerializeField] Vector3 directionToPlayerVDT;
    [SerializeField] Vector3 VDTprojectedXY;
    [SerializeField] Vector3 positionInTargetSpace;
    [SerializeField] Vector3 forwardInVerticalDrivesSpace;
    [SerializeField] float angle1;


    private void Start()
    {
        player = FindObjectOfType<PlayerMarker>().transform;
        verticalDrivesTransform = VerticalDrives.transform;

    }

    void Update()
    {

        //verticalDrivesTransform

        //Debug.DrawRay(verticalDrivesTransform.position, transform.forward, Color.white);

        directionToPlayerVDT = player.position - verticalDrivesTransform.position;
        //Debug.DrawRay(verticalDrivesTransform.position, directionToPlayerVDT, Color.yellow);

        // Получите локальный вектор в системе координат объекта VerticalDrives
        Vector3 localDirection = verticalDrivesTransform.InverseTransformDirection(directionToPlayerVDT);

        // Проекция на плоскость XZ
        Vector3 projectedXZ = Vector3.ProjectOnPlane(localDirection, Vector3.up);
        //Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.TransformDirection(projectedXZ), Color.red);

        // Проекция на плоскость XY
        Vector3 projectedXY = Vector3.ProjectOnPlane(localDirection, Vector3.forward);
        //Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.TransformDirection(projectedXY), Color.green);


        // важно


        // Проекция на плоскость YZ
        Vector3 projectedYZ = Vector3.ProjectOnPlane(localDirection, Vector3.right);
        Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.TransformDirection(projectedYZ), Color.blue);


        // важно

        /*
        angle = Vector3.Angle(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        if (angle > 0.1f)
        {
            // Находим ось вращения
            rotationAxis = Vector3.Cross(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ)); // Векторное произведение
            Debug.DrawRay(verticalDrivesTransform.position, rotationAxis, Color.black);

            // Вычисляем скалярное произведение между rotationAxis и Vector3.up
            float dotProduct = Vector3.Dot(rotationAxis, Vector3.up);

            // Определяем направление вращения
            if (Mathf.Approximately(dotProduct, 0)) // Если dotProduct близок к нулю, значит ось вращения близка к горизонтали
            {
                // Определение направления вращения (по или против часовой стрелки)
                rotationDirectionScalyrnoeProizvedenie = Vector3.Dot(rotationAxis, Vector3.right); // Скалярное произведение

                if (rotationDirectionScalyrnoeProizvedenie > 0)
                {
                    rotationDirection = 1;
                }
                else
                {
                    rotationDirection = -1;
                }
            }
            else
            {
                rotationDirection = 1; // Если ось вращения вертикальна, всегда вращаем в одном направлении
            }

            // Вращаем объект вокруг этой оси с заданной скоростью и направлением
            verticalDrivesTransform.Rotate(Vector3.right * rotationSpeed * rotationDirection * Time.deltaTime);
        }

        */

        
        angle = Vector3.Angle(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        angle1 = Vector3.Angle(transform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        if (angle1 < 35f)
        {

        
            if (angle > 0.1f)
            {
                // Находим ось вращения
                rotationAxis = Vector3.Cross(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ)); //векторное произведение
                Debug.DrawRay(verticalDrivesTransform.position, rotationAxis, Color.black);
                // Определение направления вращения (по или против часовой стрелки)
                rotationDirectionScalyrnoeProizvedenie = Vector3.Dot(rotationAxis, transform.right); // скалярное произведение
                Debug.DrawRay(verticalDrivesTransform.position, transform.forward, Color.red);
                if (rotationDirectionScalyrnoeProizvedenie > 0)
                {
                    rotationDirection = 1; 
                }
                else
                {
                    rotationDirection = -1;
                }


                // Вращаем объект вокруг этой оси с заданной скоростью и направлением
                verticalDrivesTransform.Rotate(Vector3.right * rotationSpeed * rotationDirection * Time.deltaTime);
            }
        }


        // Отрисовываем луч от позиции объекта в направлении игрока
        //Debug.DrawRay(verticalDrivesTransform.position, directionToPlayerVDT, Color.red);
        //Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.forward, Color.white);
        // Проекция на плоскость XY
        forwardInVerticalDrivesSpace = verticalDrivesTransform.TransformDirection(verticalDrivesTransform.forward);
        //Debug.DrawRay(verticalDrivesTransform.position, forwardInVerticalDrivesSpace, Color.white); // важно

        VDTprojectedXY = Vector3.ProjectOnPlane(directionToPlayerVDT, verticalDrivesTransform.forward);
        //Debug.DrawRay(verticalDrivesTransform.position, VDTprojectedXY, Color.blue); // важно

        //positionInTargetSpace = verticalDrivesTransform.InverseTransformPoint(directionToPlayerVDT);
        //Debug.Log("вертик" + positionInTargetSpace); // позиция игрока в вертикальных координатах координатах
        //Debug.DrawRay(verticalDrivesTransform.position, directionToPlayerVDT, Color.red);



        //verticalDrivesTransform


        //Debug.DrawRay(transform.position, transform.forward, Color.white);
        // Поворачиваем объект вокруг его локальной оси Y
        //transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);

        // Проверка, что у нас есть ссылка на игрока
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }

        // Находим направление к игроку
        directionToPlayer = player.position - transform.position;

        Debug.Log("норм" + player.position); // позиция игрока в основных координатах

        // Отрисовываем луч от позиции объекта в направлении игрока
        //Debug.DrawRay(transform.position, directionToPlayer, Color.red);

        // Проекция на плоскость XZ
        projectedXZ = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);
        Debug.DrawRay(transform.position, projectedXZ, Color.green);

        // Проекция на плоскость XY
        //Vector3 projectedXY = Vector3.ProjectOnPlane(directionToPlayer, Vector3.forward);
        //Debug.DrawRay(transform.position, projectedXY, Color.blue); // важно

        // Проекция на плоскость YZ
        projectedYZ = Vector3.ProjectOnPlane(directionToPlayer, Vector3.right);
        Debug.DrawRay(transform.position, projectedYZ, Color.yellow);


        // Находим угол между directionToPlayer и плоскостью XZ
        angleXZ = Vector3.Angle(directionToPlayer, Vector3.up);

        // Находим угол между directionToPlayer и плоскостью XY
        angleXY = Vector3.Angle(directionToPlayer, Vector3.forward);

        // Находим угол между directionToPlayer и плоскостью YZ
        angleYZ = Vector3.Angle(directionToPlayer, Vector3.right);

        // Выводим углы в консоль
        //Debug.Log("Угол между directionToPlayer и плоскостью XZ: " + angleXZ);
        //Debug.Log("Угол между directionToPlayer и плоскостью XY: " + angleXY);
        //Debug.Log("Угол между directionToPlayer и плоскостью YZ: " + angleYZ);

        localXZ = transform.up;
        localXY = transform.forward;
        localYZ = transform.right;

        // Находим локальные углы между directionToPlayer и плоскостями объекта
        LangleXZ = Vector3.Angle(directionToPlayer, transform.TransformDirection(localXZ));
        LangleXY = Vector3.Angle(directionToPlayer, transform.TransformDirection(localXY));
        LangleYZ = Vector3.Angle(directionToPlayer, transform.TransformDirection(localYZ));

        // Выводим локальные углы в консоль
        //Debug.Log("Локальный угол между directionToPlayer и плоскостью XZ: " + LangleXZ);
        //Debug.Log("Локальный угол между directionToPlayer и плоскостью XY: " + LangleXY);
        //Debug.Log("Локальный угол между directionToPlayer и плоскостью YZ: " + LangleYZ);


        // Находим угол между текущим направлением объекта и целевым направлением

        /*  save

        angle = Vector3.Angle(transform.forward, projectedXZ);
        if (angle > 0.1f)
        {
            // Находим ось вращения
            rotationAxis = Vector3.Cross(transform.forward, projectedXZ); //векторное произведение
            Debug.DrawRay(transform.position, rotationAxis, Color.black);
            // Определение направления вращения (по или против часовой стрелки)
            rotationDirectionScalyrnoeProizvedenie = Vector3.Dot(rotationAxis, Vector3.up); // скалярное произведение
            if(rotationDirectionScalyrnoeProizvedenie > 0)
            {
                rotationDirection = 1;
            }
            else
            {
                rotationDirection = -1;
            }
            

            // Вращаем объект вокруг этой оси с заданной скоростью и направлением
            transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
        }

        */


        angle = Vector3.Angle(transform.forward, projectedXZ);
        if (angle > 0.1f)
        {
            // Находим ось вращения
            rotationAxis = Vector3.Cross(transform.forward, projectedXZ); //векторное произведение
            Debug.DrawRay(transform.position, rotationAxis, Color.black);
            // Определение направления вращения (по или против часовой стрелки)
            rotationDirectionScalyrnoeProizvedenie = Vector3.Dot(rotationAxis, transform.up); // скалярное произведение
            if (rotationDirectionScalyrnoeProizvedenie > 0)
            {
                rotationDirection = 1;
            }
            else
            {
                rotationDirection = -1;
            }


            // Вращаем объект вокруг этой оси с заданной скоростью и направлением
            transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
        }

    }
}
