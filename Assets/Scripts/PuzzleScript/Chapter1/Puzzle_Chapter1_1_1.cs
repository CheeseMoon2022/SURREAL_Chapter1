using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Chapter1_1_1 : Puzzle
{
    public GameObject mouth1,mouth2;
    public GameObject jigsaw1;
    public GameObject[] jigsaws;
    public GameObject chicken;
    public GameObject diag1;
    public bool once = false;
    public int endFlag = 0;
    public override void puzzleStart()
    {
        //该谜题初始：左边嘴巴播放动画，出现拼图1，右边嘴巴动，出现拼图碎片
        mouth1.GetComponent<Animation>().Play("Mouth_Talk");
        jigsaw1.SetActive(true);
        jigsaw1.GetComponent<Animation>().Play("Jigsaw_Enter_1");
        Invoke("instJigsaws", 2);

    }

    private void Update()
    {
        if(!once && endFlag == jigsaws.Length)
        {
            //所有拼图都已归位
            once = true;
            Invoke("puzzleEnd", 1);
        }
    }

    public override void puzzleEnd()
    {
        //激活新素材,播放对应动画
        diag1.SetActive(true);
        chicken.SetActive(true);
        chicken.GetComponent<Animation>().Play("Chicken_Appear");     
        //删除不需要的素材
        for (int i = 0; i <= transform.childCount - 1; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        isEnd = true;
    }

    private void instJigsaws()
    {
        //嘴巴动
        mouth2.GetComponent<Animation>().Play("Mouth_Talk");
        //激活碎片
        for (int i=0;i<=jigsaws.Length-1;i++)
        {
            jigsaws[i].SetActive(true);
            jigsaws[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-400,-300), Random.Range(100, 150)));
        }
    }


}
