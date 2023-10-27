using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GudtestRotationGun : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока

    private void Start()
    {
        player = FindObjectOfType<playerGetDamage>().transform;
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

        // Игнорируем изменения по высоте (ось Y)
        directionToPlayer.y = 0;

        // Создаем кватернион для вращения
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Применяем кватернион для изменения только вращения по оси Y
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
    }
}
