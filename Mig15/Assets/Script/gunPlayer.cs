using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunPlayer : MonoBehaviour
{
    public float LinDamage = 0f;
    public float MultDamage = 1f;
    public GameObject bullet;
    public Transform shotPointL;
    public Transform shotPointR;
    private float timeBtwShots = 0;
    [SerializeField] float startTimeBtwShots = 1;
    [SerializeField] GameObject _ImageSmallGun;
    Image ImageSmallGun;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwShots = Progress.Instance.PlayerInfo.TimeBetwinShots;
        ImageSmallGun = _ImageSmallGun.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageSmallGun.fillAmount = (startTimeBtwShots - timeBtwShots) / startTimeBtwShots;
        if (timeBtwShots <= 0)
        {
            if (timeBtwShots < 0)
            {
                timeBtwShots = 0;
            }
            bullet.GetComponent<puly>().damage = (LinDamage + bullet.GetComponent<puly>().damage) * MultDamage;
            if (Input.GetKey(KeyCode.W))
            {
                Instantiate(bullet, shotPointL.position, shotPointL.rotation);
                Instantiate(bullet, shotPointR.position, shotPointR.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        
    }
}