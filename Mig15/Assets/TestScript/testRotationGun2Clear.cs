using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotationGun2Clear : MonoBehaviour
{

    public float rotationSpeed = 3f; // Скорость вращения (градусы в секунду)
    public Transform player; // Ссылка на объект игрока

    [SerializeField] float angle; // угол между направлением куда смотрит башня и Проекцией на плоскость XZ вектора направленного к игроку
    [SerializeField] float VertAngle;  // угол между направлением куда смотрит ствол и Проекцией на плоскость YZ вектора направленного к игроку
    [SerializeField] float rotationDirection;  // переменная равная 1 или -1 для вращения в нужную сторону
    [SerializeField] float rotationDirectionScalyrnoeProizvedenie; // скалярное произведение rotationAxis на transform.right
    [SerializeField] Vector3 directionToPlayer; // вектор указывающий на игрока от центра башни
    [SerializeField] Vector3 projectedXZ; // Проекция на плоскость XZ вектора directionToPlayer

    [SerializeField] Vector3 rotationAxis; //векторное произведение вектора куда смотрит башня на вектор projectedXZ

    public GameObject VerticalDrives; // Ссылка на объект вертикальные приводы и пкушка

    Transform verticalDrivesTransform; // компонент трансформ для VerticalDrives

    [SerializeField] Vector3 directionToPlayerVDT;

    [SerializeField] float LimitAngle; // максимальный угол наклона ствола и вверх и вниз

    [SerializeField] Vector3 VertikalRotationAxis; //векторное произведение вектора куда смотрит башня на вектор projectedXZ

    [SerializeField] float rotationDirectionScalyrnoeProizvedenieVert; // скалярное произведение rotationAxis на transform.right

    [SerializeField] float rotationDirectionVert; // переменная равная 1 или -1 для вращения в нужную сторону


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMarker>().transform;
        verticalDrivesTransform = VerticalDrives.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }


        // вертикально

        directionToPlayerVDT = player.position - verticalDrivesTransform.position;

        // Получите локальный вектор в системе координат объекта VerticalDrives
        Vector3 localDirection = verticalDrivesTransform.InverseTransformDirection(directionToPlayerVDT);

        // Проекция на плоскость YZ
        Vector3 projectedYZ = Vector3.ProjectOnPlane(localDirection, Vector3.right);
        Debug.DrawRay(verticalDrivesTransform.position, verticalDrivesTransform.TransformDirection(projectedYZ), Color.blue);

        VertAngle = Vector3.Angle(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        LimitAngle = Vector3.Angle(transform.forward, verticalDrivesTransform.TransformDirection(projectedYZ));
        if (LimitAngle < 35f)
        {

            if (VertAngle > 0.1f)
            {
                // Находим ось вращения
                VertikalRotationAxis = Vector3.Cross(verticalDrivesTransform.forward, verticalDrivesTransform.TransformDirection(projectedYZ)); //векторное произведение
                Debug.DrawRay(verticalDrivesTransform.position, VertikalRotationAxis, Color.black);
                // Определение направления вращения (по или против часовой стрелки)
                rotationDirectionScalyrnoeProizvedenieVert = Vector3.Dot(VertikalRotationAxis, transform.right); // скалярное произведение
                Debug.DrawRay(verticalDrivesTransform.position, transform.forward, Color.red);
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


        // вертикально


        // горизонтально

        directionToPlayer = player.position - transform.position;

        // Проекция на плоскость XZ
        projectedXZ = Vector3.ProjectOnPlane(directionToPlayer, Vector3.up);
        Debug.DrawRay(transform.position, projectedXZ, Color.green);

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

        // горизонтально
    }

}
