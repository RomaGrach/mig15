using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPlayer : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPointL;
    public Transform shotPointR;
    private float timeBtwShots = 0;
    float startTimeBtwShots = 1;
    // Start is called before the first frame update
    void Start()
    {
        startTimeBtwShots = Progress.Instance.PlayerInfo.TimeBetwinShots;
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