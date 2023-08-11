using UnityEngine;
using UnityEngine.UI;

public class PlayerMouve : MonoBehaviour
{
    public float movementSpeed = 5f; // Скорость перемещения объекта по оси X
     //public animPlayer animPlayer;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;
    [SerializeField] Animator anim;
    //public GameObject playerplain; // Ссылка на объект, который выполняет анимацию
    //private Animator anim;

    private void Start()
    {
        
    }

    void Update()
    {
        if (isMovingLeft || Input.GetKey(KeyCode.A))
        {
            //animPlayer.animstopMovingRight();
            //animPlayer.animisMovingLeft();
            anim.SetBool("leftRotateStart", true);
            MoveObject(-1f);
        }
        else if (isMovingRight || Input.GetKey(KeyCode.D))
        {
            //animPlayer.animstopMovingLeft();
            //animPlayer.animisMovingRight();
            anim.SetBool("RightRotateStart", true);
            MoveObject(1f);
        }
        else
        {
            anim.SetBool("RightRotateStart", false);
            anim.SetBool("leftRotateStart", false);
            //animPlayer.animstopMoving();
            //if (animPlayer.isStop) {
            //animPlayer.animstopMoving();
            //}
        }
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
        Vector3 movement = new Vector3(direction, 0f, 0f) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
