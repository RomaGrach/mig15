using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGoToPosition : MonoBehaviour
{
    public float pozitionX = 5;
    public float pozitionY = 100.04f;
    public float pozitionZ = 5;
    public float initialMovementSpeed = 2f; // Исходная скорость движения
    public float rotationSpeed = 100f; // Скорость поворота
    float XRand = 5;
    float YRand = 100.04f;
    float ZRand = 5;
    public bool done = false;
    private bool slowedDown = false; // Флаг для определения, было ли замедление
    private float movementSpeed; // Текущая скорость движения
    private Vector3 initialPosition; // Исходная позиция

    private void Start()
    {
        pozitionX = Random.Range(-2f, 2f);
        pozitionZ = Random.Range(2.7f, 3.5f);
        XRand = RN();
        YRand = RN();
        ZRand = RN();
        movementSpeed = initialMovementSpeed; // Инициализируем скорость
        initialPosition = transform.position; // Сохраняем исходную позицию
    }

    private float RN()
    {
        return Random.Range(-1f, 1f);
    }

    private float RN1()
    {
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

        // Вычисляем расстояние до цели
        float distanceToTarget = Vector3.Distance(transform.position, new Vector3(pozitionX, pozitionY, pozitionZ));

        // Вычисляем направление движения
        //Vector3 targetDirection = new Vector3(pozitionX - transform.position.x, pozitionY - transform.position.y, pozitionZ - transform.position.z).normalized;

        // Вычисляем ротацию в сторону движения
        //Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // Плавно поворачиваем объект в сторону движения
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Проверяем расстояние и замедляем, если необходимо
        if (distanceToTarget <= 10f)
        {
            if (!slowedDown)
            {
                movementSpeed *= 0.2f; // Уменьшаем скорость вдвое
                slowedDown = true; // Устанавливаем флаг замедления
            }

            // Поворачиваем объект в исходную позицию со скоростью rotationSpeed
            Quaternion rotationToInitialPosition = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
            transform.rotation = rotationToInitialPosition;
        }
        else
        {
            // Восстанавливаем исходную скорость
            movementSpeed = initialMovementSpeed;
            slowedDown = false; // Сбрасываем флаг замедления
                                // Вычисляем направление движения
            Vector3 targetDirection = new Vector3(pozitionX - transform.position.x, pozitionY - transform.position.y, pozitionZ - transform.position.z).normalized;

            // Вычисляем ротацию в сторону движения
            Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

            // Плавно поворачиваем объект в сторону движения
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

        // Выполняем движение к цели
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(pozitionX, pozitionY, pozitionZ), step);
    }
}








/*
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
    public float slowdownDistance = 10f; // Расстояние, на котором начинается замедление
    public bool done = false;

    private Vector3 windDirection; // Направление ветра
    private float windStrength;    // Сила ветра
    private float maxWindStrength = 5f; // Максимальная сила ветра
    private float windChangeInterval = 1f; // Интервал смены направления ветра
    private float windChangeTimer = 0f;

    private void Start()
    {
        pozitionX = Random.Range(-2f, 2f);
        pozitionZ = Random.Range(2.7f, 3.5f);

        // Инициализируем случайное направление ветра
        windDirection = Random.insideUnitSphere;
        windDirection.y = 0f; // Убираем вертикальную составляющую
        windDirection.Normalize();

        // Устанавливаем максимальную силу ветра
        windStrength = maxWindStrength;

        // Устанавливаем таймер для изменения направления ветра
        windChangeTimer = windChangeInterval;
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(pozitionX, pozitionY, pozitionZ);
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // Уменьшаем силу ветра постепенно
        windStrength -= maxWindStrength * Time.deltaTime;
        windStrength = Mathf.Clamp(windStrength, 0f, maxWindStrength);

        // Таймер для изменения направления ветра
        windChangeTimer -= Time.deltaTime;
        if (windChangeTimer <= 0f)
        {
            // Случайно меняем направление ветра
            windDirection = Random.insideUnitSphere;
            windDirection.y = 0f;
            windDirection.Normalize();

            // Сбрасываем таймер изменения направления ветра
            windChangeTimer = windChangeInterval;
        }

        // Вычисляем новую позицию с учетом влияния ветра
        Vector3 windOffset = windDirection * windStrength * Time.deltaTime;

        // Вычисляем направление движения
        Vector3 targetDirection = (targetPosition - transform.position).normalized;

        // Добавляем влияние ветра к направлению движения
        targetDirection += windOffset.normalized;

        // Нормализуем получившееся направление
        targetDirection.Normalize();

        // Вычисляем ротацию в сторону движения
        Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // Плавно поворачиваем объект в сторону движения
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Выполняем движение к цели с учетом замедления
        if (distanceToTarget > slowdownDistance)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition + windOffset, step);
        }
        else
        {
            // Начинаем замедляться, используя уменьшенную скорость
            float slowdownFactor = Mathf.Clamp01(distanceToTarget / slowdownDistance);
            float step = movementSpeed * slowdownFactor * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition + windOffset, step);

            // Если объект близко к цели, завершаем движение
            if (distanceToTarget < 0.1f)
            {
                done = true;
            }
        }
    }
}


*\



/*
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
    public float slowdownDistance = 10f; // Расстояние, на котором начинается замедление
    public bool done = false;

    private Vector3 windDirection; // Направление ветра
    private float windStrength;    // Сила ветра

    private void Start()
    {
        pozitionX = Random.Range(-2f, 2f);
        pozitionZ = Random.Range(2.7f, 3.5f);

        // Инициализируем случайное направление ветра
        windDirection = Random.insideUnitSphere;
        windDirection.y = 0f; // Убираем вертикальную составляющую
        windDirection.Normalize();

        // Инициализируем случайную силу ветра
        windStrength = Random.Range(0f, 5f);
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(pozitionX, pozitionY, pozitionZ);
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // Случайно меняем направление ветра в каждом кадре
        windDirection = Random.insideUnitSphere;
        windDirection.y = 0f;
        windDirection.Normalize();

        // Вычисляем новую позицию, учитывая направление ветра
        Vector3 windOffset = windDirection * windStrength * Time.deltaTime;

        // Вычисляем направление движения
        Vector3 targetDirection = (targetPosition - transform.position + windOffset).normalized;

        // Вычисляем ротацию в сторону движения
        Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // Плавно поворачиваем объект в сторону движения
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Проверяем угол между текущим направлением и направлением к цели
        float angleToTarget = Vector3.Angle(transform.forward, targetDirection);

        // Если угол меньше определенного порога, устанавливаем done в true
        if (angleToTarget < 5f)
        {
            done = true;
        }

        // Выполняем движение к цели с учетом замедления
        if (distanceToTarget > slowdownDistance)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition + windOffset, step);
        }
        else
        {
            // Начинаем замедляться, используя уменьшенную скорость
            float slowdownFactor = Mathf.Clamp01(distanceToTarget / slowdownDistance);
            float step = movementSpeed * slowdownFactor * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition + windOffset, step);

            // Если объект близко к цели, завершаем движение
            if (distanceToTarget < 0.1f)
            {
                done = true;
            }
        }
    }
}

*\



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
    public float slowdownDistance = 10f; // Расстояние, на котором начинается замедление
    public bool done = false;

    private void Start()
    {
        pozitionX = Random.Range(-2f, 2f);
        pozitionZ = Random.Range(2.7f, 3.5f);
    }

    private void Update()
    {
        Vector3 targetPosition = new Vector3(pozitionX, pozitionY, pozitionZ);
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        // Вычисляем направление движения
        Vector3 targetDirection = (targetPosition - transform.position).normalized;

        // Вычисляем ротацию в сторону движения
        Quaternion targetRotation = Quaternion.LookRotation(-targetDirection, Vector3.up);

        // Плавно поворачиваем объект в сторону движения
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Выполняем движение к цели с учетом замедления
        if (distanceToTarget > slowdownDistance)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            // Начинаем замедляться, используя уменьшенную скорость
            float slowdownFactor = Mathf.Clamp01(distanceToTarget / slowdownDistance);
            float step = movementSpeed * slowdownFactor * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Если объект близко к цели, завершаем движение
            if (distanceToTarget < 0.1f)
            {
                done = true;
            }
        }
    }
}


/*
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
*\
/*
_____________________
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

}
 */
