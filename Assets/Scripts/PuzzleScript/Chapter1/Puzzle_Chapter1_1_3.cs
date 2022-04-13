using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Chapter1_1_3 : Puzzle
{
    // Start is called before the first frame update
    public GameObject mouth1, mouth2, chicken,timeline;
    public bool endFlag = false;
    private bool once = false;
    public override void puzzleStart()
    {
        //播放嘴巴微笑流口水的动画
        mouth1.GetComponent<Animation>().Play("Mouth_Smile");
        //mouth1.GetComponent<Animation>().PlayQueued("Mouth_Drool");
        mouth2.GetComponent<Animation>().Play("Mouth_Smile");
        //mouth2.GetComponent<Animation>().PlayQueued("Mouth_Drool");
        //

    }

    private void Update()
    {
        if(!once && endFlag)
        {
            //Invoke("puzzleEnd",1);
            puzzleEnd();
            once = true;
        }
    }

    public override void puzzleEnd()
    {
        //开启时间轴
        timeline.SetActive(true);
        //销毁鸡
        Destroy(chicken);
        isEnd = true;
    }

}
