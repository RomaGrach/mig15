using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiController : MonoBehaviour
{
    public enemyGoToPosition enemyGoToPosition;
    public enemiMouve enemiMouve;
    public enemiGan enemiGan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGoToPosition.done)
        {
            enemyGoToPosition.enabled = false;
            enemiMouve.enabled = true;
            enemiGan.enabled = true;
        }
    }
}
