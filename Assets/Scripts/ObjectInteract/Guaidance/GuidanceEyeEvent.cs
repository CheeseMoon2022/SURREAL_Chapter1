using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceEyeEvent: ObjInteract
{
    // Start is called before the first frame update
    public GameObject fallingTimeline;
    public float param;//

    private void OnMouseOver()
    {
        //判断鼠标位置
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
        //Vector3 mousePos = Input.mousePosition;
        //Debug.Log("InputMousePos:" + Input.mousePosition);
        mousePos.z = 0;
        //Debug.Log("mousePos:" + mousePos);
        Vector3 dist = this.transform.position - mousePos;
        //Debug.Log("dist:" + dist);
        if (dist.x > 0)
        {
            //鼠标在右侧
            //Debug.Log(dist.magnitude / param);
            anim.SetFloat("MousePos", - dist.magnitude / param);
        }
        if (dist.x <= 0)
        {
            //鼠标在左侧
            anim.SetFloat("MousePos", dist.magnitude / param);
        }
    }

    private void OnMouseDown()
    {
        anim.SetBool("isClicked", true);
        fallingTimeline.SetActive(true);
    }

}
