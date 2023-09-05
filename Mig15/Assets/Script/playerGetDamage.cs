using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGetDamage : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffectPrefab;
    public int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            hp -= 1;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

    }
}
