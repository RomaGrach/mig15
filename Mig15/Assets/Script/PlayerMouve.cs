using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouve : MonoBehaviour
{
    public float movementSpeed = 5f; // Скорость перемещения объекта по оси X
                                     //public animPlayer animPlayer;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    private int first = 0;
    [SerializeField] Animator anim;
    public bool mobile = false;
    public FloatingJoystick FJ;
    public GameObject DJ;
    //public GameObject playerplain; // Ссылка на объект, который выполняет анимацию
    //private Animator anim;

    private void Start()
    {
        /*
        if (SystemInfo.deviceType == DeviceType.Handheld || mobile)
        {
            mobile = true;
            FJ.resetJostic();
        }
        else
        {
            DJ.SetActive(false);
        }
        */
    }


    void Update()
    {

        //FJ.resetJostic(); для сброса джостика
        
        

        bool left = false;
        bool right = false;

        if ((isMovingLeft || Input.GetKey(KeyCode.A) || (FJ.Horizontal <0)))
        {
            left = true;
        }
        if (isMovingRight || Input.GetKey(KeyCode.D) || (FJ.Horizontal > 0))
        {
            right = true;
        }

        if (left && !right)
        {
            first = -1;
            clearAnim();
            anim.SetBool("left", true);
            MoveObject(-1f);
        }
        else if (!left && right)
        {
            first = 1;
            clearAnim();
            anim.SetBool("right", true);
            MoveObject(1f);
        }
        else if (left && right)
        {
            if (first == -1)
            {
                clearAnim();
                anim.SetBool("right", true);
                MoveObject(1f);
            }
            else
            {
                clearAnim();
                anim.SetBool("left", true);
                MoveObject(-1f);
            }
        }
        else
        {
            first = 0;
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
        transform.position = newPosition;
        
    }

    public void clearAnim()
    {
        anim.SetBool("left", false);
        anim.SetBool("right", false);
    }
    public void StartMovingLeft()
    {
        isMovingLeft = true;
    }

    public void StartMovingRight()
    {
        isMovingRight = true;
    }

    public void StopMovingLeft()
    {
        isMovingLeft = false;
    }

    public void StopMovingRight()
    {
        isMovingRight = false;
    }

    private void MoveObject(float direction)
    {
        // Движение объекта вправо-влево
        // Мы перемещаем объект по оси X, оставляя Y и Z без изменений
        if(FJ.Horizontal != 0)
        {
            Vector3 movement = new Vector3(FJ.Horizontal, 0f, 0f) * movementSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
        else
        {
            Vector3 movement = new Vector3(direction, 0f, 0f) * movementSpeed * Time.deltaTime;
            transform.Translate(movement);
        }
        
    }
    /*
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //animPlayer.animstopMovingRight();
            //animPlayer.animisMovingLeft();
            _animator.SetBool("left", true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //animPlayer.animstopMovingRight();
            //animPlayer.animisMovingLeft();
            _animator.SetBool("right", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //animPlayer.animstopMovingRight();
            //animPlayer.animisMovingLeft();
            _animator.SetBool("left", false);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            //animPlayer.animstopMovingRight();
            //animPlayer.animisMovingLeft();
            _animator.SetBool("right", false);
        }
    }
    */
}
