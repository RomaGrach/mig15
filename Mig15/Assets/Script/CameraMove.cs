using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform _target;
    public float cameraBox = 0.1f;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_target)
        {
            if (Mathf.Abs(_target.position.x - transform.position.x) > cameraBox)
            {
                transform.position = transform.position + (new Vector3(_target.position.x - transform.position.x, 0f, 0f).normalized * speed * Time.deltaTime);
            }
            else
            {
                if (Mathf.Abs(_target.position.x - transform.position.x) > 0.01f)
                {
                    transform.position = transform.position + (new Vector3(_target.position.x - transform.position.x, 0f, 0f).normalized * 0.05f * Time.deltaTime);
                }
            }
            //transform.position = _target.position + new Vector3(0f, 0.11f, -0.287f)

        }

    }
}
