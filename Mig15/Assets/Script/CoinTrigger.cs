using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    public float speed = 0.1f;
    public float wspeed = 1f;
    public float rotation_speed = 10f;
    public float distanceZ = 10f;
    public float wRange = 1f;
    public Vector3 pos = new Vector3(0f, 100f, 0f);
    private Vector3 end;
    private float multRot = 1f;
    private bool flag = false;
    public float x;

    // Start is called before the first frame update
    void Start()
    {
        pos.z = distanceZ;
        transform.position = pos;
        end = pos;
        end.z = -1f;
        end.x = wRange;

    }
    // Update is called once per frame
    void Update()
    {
       
        
        Vector3 curPos = transform.position;
        transform.position = Vector3.MoveTowards(curPos, end, speed*Time.deltaTime);

        Vector3 Side = transform.position;
        Side.z = transform.position.z;
        if (transform.position.x >= wRange && !flag)
        {
            end.x = -wRange;
            Side.x = -wRange;
            flag = true;
        }
        else if (transform.position.x <= -wRange && flag)
        {
            end.x = wRange;
            Side.x = wRange;
            flag = false;
        }
        else Side.x = end.x;
        transform.position = Vector3.MoveTowards(curPos, Side, wspeed * Time.deltaTime);


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
        
        if (other.gameObject.tag == "bulletPlayer")
        {
            Destroy(gameObject);
            Debug.Log(gameObject.tag);
        }
    }
}
