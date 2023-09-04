
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiMouve : MonoBehaviour
{
    int mouve = 0;
    public float movementSpeed = 0.2f;
    public int hp = 3;
    [SerializeField] GameObject _bricksEffectPrefab;

    private void Start()
    {
        StartCoroutine(Create3dObjects(4f));
    }

    private void Update()
    {
        // Движение объекта в зависимости от переменной "mouve"
        if (mouve == 0)
        {
            MoveObject(-1f);
        }
        else if (mouve == 1)
        {
            MoveObject(1f);
        }
        else if (mouve == 2)
        {
            MoveObject(1.3f);
        }
        else if (mouve == 3)
        {
            MoveObject(-1.3f);
        }
        else
        {
            mouve = 0;
        }

        // Ограничение движения по оси X от -3 до 3
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
        transform.position = newPosition;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletPlayer")
        {
            hp -= 1;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Create3dObjects(float wait)
    {
        yield return new WaitForSeconds(wait);
        mouve += 1;
        StartCoroutine(Create3dObjects(4f));
    }

    private void MoveObject(float direction)
    {
        Vector3 movement = new Vector3(direction, 0f, 0f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
/* фокус как
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiMouve : MonoBehaviour
{
    int mouve = 0;
    public float movementSpeed = 0.2f;
    public int hp = 3;
    [SerializeField] GameObject _bricksEffectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create3dObjects(4f));
    }

    // Update is called once per frame
    void Update()
    {
        if (mouve == 0)
        {
            MoveObject(-1f);
        }
        else if (mouve == 1)
        {
            MoveObject(1f);
        }
        else if (mouve == 2)
        {
            MoveObject(1.3f);
        }
        else if (mouve == 3)
        {
            MoveObject(-1.3f);
        }
        else
        {
            mouve = 0;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bulletPlayer")
        {
            hp -= 1;
            Instantiate(_bricksEffectPrefab, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }

    }
    private IEnumerator Create3dObjects(float wait)
    {
        // таймер
        yield return new WaitForSeconds(wait);
        mouve += 1;
        StartCoroutine(Create3dObjects(4f));
    }
    private void MoveObject(float direction)
    {
        // Движение объекта вправо-влево
        // Мы перемещаем объект по оси X, оставляя Y и Z без изменений
        Vector3 movement = new Vector3(direction, 0f, 0f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
*/
