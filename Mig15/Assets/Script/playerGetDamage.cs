using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGetDamage : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffectPrefab;
    public float hp = 5;
    public float Maxhp = 5;
    Image healthBar;
    [SerializeField] GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        Maxhp = Progress.Instance.PlayerInfo.MaxHP;
        hp = Maxhp;
        healthBar = Image.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = hp / Maxhp;
        if (hp <= 0)
        {
            Debug.Log($"’п дошло до нул€");
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
