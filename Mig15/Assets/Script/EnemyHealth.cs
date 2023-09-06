using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnDie;
    public int hp = 3;
    [SerializeField] GameObject _bricksEffectPrefab;

    private void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletPlayer")
        {
            hp -= 1;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        OnDie.Invoke();
    }
}
