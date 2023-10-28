using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B29GunsController : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public Transform horizontalPart; // Первая часть пушки (по оси Y)
    public Transform verticalPart;   // Вторая часть пушки (по оси X)

    public float maxHorizontalRotation = 3360f; // Максимальный угол поворота пушки по горизонтали (ось Y)
    public float maxVerticalRotation = 3360f;   // Максимальный угол поворота пушки по вертикали (ось X)

    private Quaternion horizontalPartBaseRotation; // Начальный угол горизонтальной части пушки
    private Quaternion verticalPartBaseRotation;   // Начальный угол вертикальной части пушки

    private void Start()
    {
        player = FindObjectOfType<playerGetDamage>().transform;
        horizontalPartBaseRotation = horizontalPart.localRotation;
        verticalPartBaseRotation = verticalPart.localRotation;
    }

    void Update()
    {
        if (player != null)
        {
            // Направляем горизонтальную часть пушки на игрока (по оси Y)
            Vector3 playerDirectionHorizontal = player.position - horizontalPart.position;
            Quaternion horizontalRotation = Quaternion.LookRotation(playerDirectionHorizontal);
            horizontalPart.localRotation = Quaternion.RotateTowards(horizontalPartBaseRotation * horizontalRotation, horizontalPart.localRotation, maxHorizontalRotation * Time.deltaTime);

            // Направляем вертикальную часть пушки на игрока (по оси X)
            Vector3 playerDirectionVertical = player.position - verticalPart.position;
            Quaternion verticalRotation = Quaternion.LookRotation(playerDirectionVertical);
            verticalPart.localRotation = Quaternion.RotateTowards(verticalPartBaseRotation * verticalRotation, verticalPart.localRotation, maxVerticalRotation * Time.deltaTime);
        }
    }
}
