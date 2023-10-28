using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunElements
{
    public GameObject[] GunForB29FrontUp;
    public GameObject[] GunForB29FrontDown;
    public GameObject[] GunForB29BackDown;
    public GameObject[] GunForB29BackUp;
    public GameObject[] GunForB29Tail;
}

[System.Serializable]
public class GunAngles
{
    public float[] GunForB29FrontUp;
    public float[] GunForB29FrontDown;
    public float[] GunForB29BackDown;
    public float[] GunForB29BackUp;
    public float[] GunForB29Tail;
}

public class B29GunController : MonoBehaviour
{
    public Transform player;
    public GunElements gunElements;
    public GunAngles gunAngles;
    public float rotationSpeed = 5.0f;

    void Start()
    {
        player = FindObjectOfType<playerGetDamage>().transform;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is not set.");
            return;
        }

        HandleGunElements(gunElements.GunForB29FrontUp, gunAngles.GunForB29FrontUp);
        HandleGunElements(gunElements.GunForB29FrontDown, gunAngles.GunForB29FrontDown);
        HandleGunElements(gunElements.GunForB29BackDown, gunAngles.GunForB29BackDown);
        HandleGunElements(gunElements.GunForB29BackUp, gunAngles.GunForB29BackUp);
        HandleGunElements(gunElements.GunForB29Tail, gunAngles.GunForB29Tail);
    }

    void HandleGunElements(GameObject[] gunElementArray, float[] maxAnglesArray)
    {
        if (gunElementArray != null && maxAnglesArray != null)
        {
            for (int i = 0; i < gunElementArray.Length; i++)
            {
                if (gunElementArray[i] != null)
                {
                    HandleHorizontalTurret(gunElementArray[i]);
                    HandleVerticalTurret(gunElementArray[i], maxAnglesArray[i]);
                }
            }
        }
    }

    void HandleHorizontalTurret(GameObject gunElement)
    {
        Vector3 directionToPlayer = player.position - gunElement.transform.position;
        directionToPlayer.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        gunElement.transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
    }

    void HandleVerticalTurret(GameObject gunElement, float maxAngle)
    {
        Vector3 directionToPlayer = player.position - gunElement.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Ограничиваем угол вращения по вертикали
        float currentAngle = gunElement.transform.localEulerAngles.x;
        float clampedAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

        // Сохраняем горизонтальное вращение
        float horizontalAngle = gunElement.transform.localEulerAngles.y;

        gunElement.transform.localEulerAngles = new Vector3(clampedAngle, horizontalAngle, 0);

        // Применяем плавное вращение
        gunElement.transform.localRotation = Quaternion.Slerp(gunElement.transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
