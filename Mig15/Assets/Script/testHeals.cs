using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testHeals : MonoBehaviour
{
    public float Maxhp = 3f;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("нету");
        if (other.gameObject.tag == "bulletPlayer")
        {
            Debug.Log("есть");
           
            hp -= other.gameObject.GetComponent<puly>().damage;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
