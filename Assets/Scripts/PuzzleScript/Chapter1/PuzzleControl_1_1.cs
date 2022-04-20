using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleControl_1_1 : PuzzleControl
{
    //public Puzzle[] puzzles;
    //private int index = 0;
    //private bool isComplete = false;
    //public string sceneName;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("puzzlesStart", 1);
    }

    public override void puzzlesStart()
    {
        puzzles[0].puzzleStart();
    }
    // Update is called once per frame
    void Update()
    {
        if(!isComplete && puzzles[index].isEnd)
        {
            if (index < puzzles.Length - 1)
            {
                index++;
                puzzles[index].puzzleStart();
            }
            else
            {
                isComplete = true;
                puzzlesComplete();
            }
        }
    }

    public override void puzzlesComplete()
    {
        Debug.Log("本小关完成");

    }

    
    public void nextScene()
    {
        //加载关卡2
        LevelManager._Ins.level = nextLevel;
        LevelManager._Ins.loadScene();
    }
}
