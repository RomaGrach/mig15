using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunPlayer : MonoBehaviour
{
    public float LinDamage = 0f;
    public float LinDamage37 = 2;
    public float MultDamage = 1f;
    public GameObject bullet;
    public GameObject bullet37;
    public Transform shotPointL;
    public Transform shotPointR;
    public Transform shotPoint37mm;
    private float timeBtwShots = 0;
    private float timeBtwShots37 = 0;
    [SerializeField] float startTimeBtwShots = 1;
    [SerializeField] float startTimeBtwShots37 = 2;
    [SerializeField] GameObject _ImageSmallGun;
    [SerializeField] GameObject _ImageBigGun;
    Image ImageSmallGun;
    Image ImageBigGun;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwShots = Progress.Instance.PlayerInfo.TimeBetwinShots;
        startTimeBtwShots37 = Progress.Instance.PlayerInfo.TimeBetwinShots37;
        ImageSmallGun = _ImageSmallGun.GetComponent<Image>();
        ImageBigGun = _ImageBigGun.GetComponent<Image>();
        MultDamage = Progress.Instance.PlayerInfo.Damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots < 0)
        {
            timeBtwShots = 0;
        }
        if (timeBtwShots37 < 0)
        {
            timeBtwShots37 = 0;
        }
        ImageSmallGun.fillAmount = (startTimeBtwShots - timeBtwShots) / startTimeBtwShots;
        ImageBigGun.fillAmount = (startTimeBtwShots37 - timeBtwShots37) / startTimeBtwShots37;
        if (Input.GetKey(KeyCode.W))
        {
            if (timeBtwShots <= 0)
            {
                bullet.GetComponent<puly>().damage = (LinDamage + bullet.GetComponent<puly>().damage) * MultDamage;
                Instantiate(bullet, shotPointL.position, shotPointL.rotation);
                Instantiate(bullet, shotPointR.position, shotPointR.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            if (timeBtwShots37 <= 0)
            {

                bullet37.GetComponent<puly>().damage = (LinDamage37 + bullet.GetComponent<puly>().damage) * MultDamage;
                Instantiate(bullet37, shotPoint37mm.position, shotPoint37mm.rotation);
                timeBtwShots37 = startTimeBtwShots37;
            }


        }
        if(timeBtwShots > 0)
        {
            timeBtwShots -= Time.deltaTime;
        }
        if(timeBtwShots37 > 0)
        {
            timeBtwShots37 -= Time.deltaTime;
        }
        /*
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
        */



    }
}