using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyControlScript : MonoBehaviour
{
    public bool moving;
    public float moveSpeed;
    public float turnSpeed;
    public Vector3 initScale;
    Vector2 worldPosLeftBottom;
    Vector2 worldPosTopRight;
    // Start is called before the first frame update
    void Start()
    {
        //moving = false;
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            worldPosLeftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0,0,30));
            worldPosTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,30));
            //Debug.Log(worldPosLeftBottom);
            //Debug.Log(worldPosTopRight);
            //Debug.Log(new Vector2(Screen.width, Screen.height));
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 30));
            faceDirection(mousePos);
            fly(mousePos);
        }
        
    }

    private void fly(Vector3 mousePos)
    {
        //模式一：始终以一个速度向右飞
        /**
        this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * flySpeed, this.transform.position.y, this.transform.position.z);
        //根据鼠标位置向上or向下
        Vector3 target = new Vector3(transform.position.x, mousePos.y, mousePos.z);
        //transform.position = Vector3.MoveTowards(this.transform.position,mousePos,Time.deltaTime * moveSpeed);
        transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * moveSpeed);
        */
        //模式二：跟随鼠标位置飞
        transform.position = Vector3.MoveTowards(this.transform.position,
                                                 new Vector3(Mathf.Clamp(mousePos.x, worldPosLeftBottom.x, worldPosTopRight.x),
                                                 Mathf.Clamp(mousePos.y, worldPosLeftBottom.y, worldPosTopRight.y),
                                                 transform.position.z), Time.deltaTime * moveSpeed);
        

    }

    private void faceDirection(Vector3 mousePos)
    {
        //改变蝴蝶朝向
        float distX = transform.position.x - mousePos.x;
        if (distX > 0 )
        {
            //在右边
            transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(-initScale.x, initScale.y, initScale.z), Time.deltaTime * turnSpeed); 
        }
        else
        {
            //在左边
            transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(initScale.x, initScale.y, initScale.z), Time.deltaTime * turnSpeed);
        }
        
    }

}
