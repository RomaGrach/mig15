using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B29Controller : MonoBehaviour
{

    public enemyGoToPosition enemyGoToPosition;
    public enemiMouve enemiMouve;
    public TurretControlB29 TurretControlB29_1;
    public TurretControlB29 TurretControlB29_2;
    public TurretControlB29 TurretControlB29_3;
    public TurretControlB29 TurretControlB29_4;
    public TurretControlB29 TurretControlB29_5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyGoToPosition.done)
        {
            if (transform.position.z < 0.001f)
            {
                FindObjectOfType<GameManager>().ShowFinishWindowBadEnd();
                // Координата Z меньше нуля
                // Ваш код здесь
            }
            enemyGoToPosition.enabled = false;
            enemiMouve.enabled = true;
            TurretControlB29_2.enabled = true;
            TurretControlB29_3.enabled = true;
            TurretControlB29_4.enabled = true;
            TurretControlB29_5.enabled = true;
            TurretControlB29_1.enabled = true;
        }
    }
}
