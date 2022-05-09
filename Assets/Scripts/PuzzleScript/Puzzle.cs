using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    //Puzzle类用于管控关卡谜题，谜题由开始->进行->结束组成，分别判断开始、进行和结束的条件 
    public bool isEnd = false;
    public virtual void puzzleStart()
    {
        //该谜题初始
    }

    public virtual void puzzleEnd()
    {
        //该谜题结束
    }
}
