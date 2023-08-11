using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puly : MonoBehaviour
{
    public float speed;
    public float gravity;
    public float lifetime;
    //private Rigidbody _rb;

    // Start is called before the first frame update
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.down * gravity * Time.deltaTime);
        //_rb.AddForce(Vector3.forward * speed * Time.fixedDeltaTime);
    }
    void Start()
    {
        //_rb = GetComponent<Rigidbody>();
        Invoke("destCube", lifetime);
    }
    private void destCube()
    {
        Destroy(gameObject);
    }
}
