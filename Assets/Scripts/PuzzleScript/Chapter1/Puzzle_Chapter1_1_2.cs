using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Puzzle_Chapter1_1_2 : Puzzle_Chapter1_1_1
{
    // Start is called before the first frame update
    public GameObject diag2;
    public Transform diag1End;
    public Transform diag2End;
    public GameObject oven;
    
    public override void puzzleStart()
    {
        //上一个对话框略微缩小，并处于右上方
        diag1.transform.DOMove(diag1End.position,1);
        diag1.transform.DOScale(diag1End.localScale, 1);
        //
        Invoke("mouthTalk", 1);
    }

    private void Update()
    {
        if (!once && endFlag == jigsaws.Length)
        {
            //所有拼图都已归位
            once = true;
            Invoke("puzzleEnd", 1);
        }
    }


    public override void puzzleEnd()
    {
        diag2.SetActive(true);
        oven.SetActive(true);
        //对话框略微缩小并移动
        diag2.transform.DOMove(diag2End.position, 1);
        diag2.transform.DOScale(diag2End.localScale, 1);
        oven.GetComponent<Animation>().Play("Oven_TurnOn");
        //改变鸡的显示图层
        chicken.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Interactive Object");
        chicken.GetComponent<SpriteRenderer>().rendererPriority = 12;

        //删除不需要的素材
        Destroy(transform.Find("Jigsaws").gameObject);
        isEnd = true;
    }

    private void mouthTalk()
    {
        chicken.GetComponent<ChickenDrag>().startPoint = chicken.transform.position;
        mouth2.GetComponent<Animation>().Play("Mouth_Talk");
        jigsaw1.SetActive(true);
        jigsaw1.GetComponent<Animation>().Play("Jigsaw_Enter_2");
        Invoke("instJigsaws", 2);
    }

    private void instJigsaws()
    {
        //嘴巴动
        mouth1.GetComponent<Animation>().Play("Mouth_Talk");
        //激活碎片
        for (int i = 0; i <= jigsaws.Length - 1; i++)
        {
            jigsaws[i].SetActive(true);
            jigsaws[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(300, 400), Random.Range(100, 150)));
        }
    }
}
