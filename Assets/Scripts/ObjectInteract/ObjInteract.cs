using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class ObjInteract : MonoBehaviour
{
    // Start is called before the first frame update
    //一个物体若有鼠标悬浮、点击和静止三种状态的动画，便可继承该类来扩充
    public Animator anim;
    void Start()
    {
        if (!anim)
        {
            anim = this.GetComponent<Animator>();
        }
    }

    private void OnMouseEnter()
    {
        anim.SetBool("isHover", true);
        
    }

    private void OnMouseExit()
    {
        anim.SetBool("isHover", false);
    }

    private void OnMouseDown()
    {
        anim.SetBool("isClicked", true);
    }

}
