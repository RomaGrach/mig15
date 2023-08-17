using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMouve : MonoBehaviour
{
    private float movementSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.z < -1000)
        {
            Destroy(gameObject);
        }
        Vector3 movement = new Vector3(0f, 0f, -1f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
