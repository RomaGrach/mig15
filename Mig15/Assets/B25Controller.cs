using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B25Controller : MonoBehaviour
{
    public enemyGoToPosition enemyGoToPosition;
    public enemiMouve enemiMouve;
    public TurretControlB29 TurretControlB25_end;
    public TurretControlB29 TurretControlB25_center;
    
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
            TurretControlB25_end.enabled = true;
            TurretControlB25_center.enabled = true;
        }
    }
}
