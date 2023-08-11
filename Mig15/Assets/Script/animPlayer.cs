using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animPlayer : MonoBehaviour
{
    private Animator anim;
    //public bool isStop = false;
    public bool right = false;
    public bool left = false;

    // Start is called before the first frame update
    void Start()
    {
         //isStop = false;
    anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void animisMovingLeft()
    {
        left = true;
        anim.SetBool("leftRotateStart", true);

    }
    public void animisMovingRight()
    {
        right = true;
        anim.SetBool("RightRotateStart", true);
    }
    public void animstopMoving()
    {
        if (right)
        {
            right = false;
            anim.SetBool("RightRotateStart", false);
        }
        if (left)
        {
            left = false;
            anim.SetBool("leftRotateStart", false);
        }
        
    }
    public void animstopMovingRight()
    {
        anim.SetBool("RightRotateStart", false);
    }
    public void animstopMovingLeft()
    {
        anim.SetBool("leftRotateStart", false);
    }
}
