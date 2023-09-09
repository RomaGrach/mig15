using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnDie;
    public float Maxhp = 3f;
    public float hp;
    Image healthBar;
    [SerializeField] GameObject Image;

    [SerializeField] GameObject _bricksEffectPrefab;
    private void Start()
    {

        hp = Maxhp;
        healthBar = Image.GetComponent<Image>();
        
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
        healthBar.fillAmount = hp / Maxhp;
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
        FindObjectOfType<ScoreManager>().killedEnemies++;
        Destroy(gameObject);
        OnDie.Invoke();
    }
}
