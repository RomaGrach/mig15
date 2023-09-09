using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGetDamage : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffectPrefab;
    public float hp;
    public float Maxhp = 3f;
    Image healthBar;
    [SerializeField] GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        hp = Maxhp;
        healthBar = Image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hp / Maxhp;
        if (hp <= 0)
        {
            FindObjectOfType<GameManager>().ShowFinishWindowBadEnd();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletEnemy")
        {
            hp -= other.gameObject.GetComponent<puly>().damage;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

    }
}
