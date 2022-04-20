using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleControl : MonoBehaviour
{
    public Puzzle[] puzzles;//谜题类组
    public int index = 0;//记录当前谜题下标
    public bool isComplete = false;//所有谜题是否完成
    public Level nextLevel;//下一关卡

    public virtual void puzzlesStart()
    {
        //谜题初始
    }

    public virtual void puzzlesComplete()
    {
        //所有谜题结束
    }
    public virtual void nextScene()
    {
        //加载下一场景
    }
}
