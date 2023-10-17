using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HealTrigger : MonoBehaviour
{
    public float linHeal = 0;
    public float multHeal = 1;
    public float speed = 0.1f;
    public float rotation_speed = 10f;
    public float distanceZ = 10f; 
    public Vector3 pos = new Vector3(0f, 100f, 0f);
    private Vector3 end;
    private float multRot = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        pos.z = distanceZ;
        transform.position = pos;
        end = pos;
        end.z = -1f;

    }
    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        transform.position = Vector3.MoveTowards(curPos, end, speed*Time.deltaTime);
        float rotX = transform.rotation.x;
        float rotY = transform.rotation.y + rotation_speed*multRot;
        float rotZ = transform.rotation.z;
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
        multRot += 1f;
        if (transform.position.z < 0f)
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            float HP = other.gameObject.GetComponent<playerGetDamage>().hp;
            float MHP = other.gameObject.GetComponent<playerGetDamage>().Maxhp;
            HP += linHeal*multHeal;
            if (HP > MHP)
            {
                HP = MHP;
            }
            other.gameObject.GetComponent<playerGetDamage>().hp = HP;
            Destroy(gameObject);
        }
    }
}
