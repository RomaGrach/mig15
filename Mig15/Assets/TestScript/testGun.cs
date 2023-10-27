using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGun : MonoBehaviour
{

    public GameObject bullet;
    public Transform shotPoint;

    private float timeBtwShots = 0;
    public float startTimeBtwShots = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(bullet, shotPoint.position, shotPoint.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
