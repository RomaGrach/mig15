using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent OnDie;
    public float Maxhp = 3f;
    public float hp;
    Image healthBar;
    [SerializeField] GameObject Image;
    //[SerializeField] Animator anim;
    [SerializeField] GameObject _bricksEffectPrefab;
    [SerializeField] GameObject[] _FireEffectPrefab;

    private void Start()
    {

        hp = Maxhp;
        healthBar = Image.GetComponent<Image>();
        
    }
    private void Update()
    {
        if (hp <= 0)
        {

            //if (_FireEffectPrefab)
            //{
            //    Instantiate(_FireEffectPrefab, transform.position, transform.rotation);
            //}
            //if (anim)
            //{
                //anim.SetBool("Dead", true);
            //}
            //else
            //{
                //Die();
            //}
            
        }
        healthBar.fillAmount = hp / Maxhp;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("нету");
        if (other.gameObject.tag == "bulletPlayer")
        {
            Debug.Log("есть");
            HitMarker();
            //hp -= Progress.Instance.PlayerInfo.Damage ;
            hp -= other.gameObject.GetComponent<puly>().damage;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
            if (hp <= 0)
            {
                ActivateAllFireEffects();
            }
        }
    }

    void ActivateAllFireEffects()
    {
        if (_FireEffectPrefab != null)
        {
            foreach (GameObject fireEffect in _FireEffectPrefab)
            {
                if (fireEffect != null)
                {
                    fireEffect.SetActive(true);
                }
            }
        }
    }

    public void Die()
    {
        GlobalEventManager.SendEnemyKilled();
        FindObjectOfType<ScoreManager>().killedEnemies++;
        Destroy(gameObject);
        OnDie.Invoke();
    }

    private void HitMarker()
    {
        // Находим объект по имени
        FindObjectOfType<hitMarkerSkript>().startHitMarker();
    }
}
