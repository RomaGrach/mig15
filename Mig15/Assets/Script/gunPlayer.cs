using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPlayer : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPointL;
    public Transform shotPointR;
    private float timeBtwShots = 0;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwShots <= 0)
        {
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