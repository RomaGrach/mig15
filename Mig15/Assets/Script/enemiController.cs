using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiController : MonoBehaviour
{
    public enemyGoToPosition enemyGoToPosition;
    public enemiMouve enemiMouve;
    public enemiGan enemiGan;
    public EnemyHealth EnemyHealth;
    public float timeDead = 5f;

    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth.hp < 0)
        {
            enemiMouve.normalMouve = false;
            StartCoroutine(DeadUje(timeDead));
        }
        if (transform.position.z < 0.001f && EnemyHealth.hp >0)
        {
            FindObjectOfType<GameManager>().ShowFinishWindowBadEnd();
            // Координата Z меньше нуля
            // Ваш код здесь
        }
        if (enemyGoToPosition.done)
        {
            enemyGoToPosition.enabled = false;
            enemiMouve.enabled = true;
            enemiGan.enabled = true;
        }
    }
    private IEnumerator DeadUje(float wait)
    {
        yield return new WaitForSeconds(wait);
        EnemyHealth.Die();
    }

    public void DeadAllReady()
    {
        dead = true;
    }

}
