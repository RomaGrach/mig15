using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotationGun1 : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public float rotationSpeed = 5.0f; // Скорость вращения

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

        // Вычисляем угол между directionToPlayer и плоскостью xOz
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        // Выводим угол в консоль
        //Debug.Log("Угол между объектом и игроком: " + angle);

        // Создаем кватернион для вращения
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Вращаем объект к игроку
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


    }
}
