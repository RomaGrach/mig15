using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotationGun : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока


    private void Start()
    {
        player = FindObjectOfType<PlayerMarker>().transform;
    }

    private void Update()
    {
        // Проверка, что у нас есть ссылка на игрока
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }

        // Находим направление к игроку
        Vector3 directionToPlayer = player.position - transform.position;

        // Находим угол между directionToPlayer и плоскостью XZ
        float angleXZ = Vector3.Angle(directionToPlayer, Vector3.up);

        // Находим угол между directionToPlayer и плоскостью XY
        float angleXY = Vector3.Angle(directionToPlayer, Vector3.forward);

        // Находим угол между directionToPlayer и плоскостью YZ
        float angleYZ = Vector3.Angle(directionToPlayer, Vector3.right);

        // Выводим углы в консоль
        Debug.Log("Угол между directionToPlayer и плоскостью XZ: " + angleXZ);
        Debug.Log("Угол между directionToPlayer и плоскостью XY: " + angleXY);
        Debug.Log("Угол между directionToPlayer и плоскостью YZ: " + angleYZ);

        Vector3 localXZ = transform.up;
        Vector3 localXY = transform.forward;
        Vector3 localYZ = transform.right;

        // Находим локальные углы между directionToPlayer и плоскостями объекта
        float LangleXZ = Vector3.Angle(directionToPlayer, transform.TransformDirection(localXZ));
        float LangleXY = Vector3.Angle(directionToPlayer, transform.TransformDirection(localXY));
        float LangleYZ = Vector3.Angle(directionToPlayer, transform.TransformDirection(localYZ));

        // Выводим локальные углы в консоль
        Debug.Log("Локальный угол между directionToPlayer и плоскостью XZ: " + LangleXZ);
        Debug.Log("Локальный угол между directionToPlayer и плоскостью XY: " + LangleXY);
        Debug.Log("Локальный угол между directionToPlayer и плоскостью YZ: " + LangleYZ);


        // Игнорируем изменения по высоте (ось Y)
        //directionToPlayer.y = 0;

        // Создаем кватернион для вращения
        //Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Применяем кватернион для изменения только вращения по оси Y
        //transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
    }
}
