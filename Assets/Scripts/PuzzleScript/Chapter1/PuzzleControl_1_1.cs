using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleControl_1_1 : MonoBehaviour
{
    public Puzzle[] puzzles;
    private int index = 0;
    private bool isComplete = false;

    // Start is called before the first frame update
    private void Start()
    {
        Invoke("puzzleStart", 1);
    }

    public void puzzleStart()
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
                puzzleComplete();
                isComplete = true;
            }
        }
    }

    public void puzzleComplete()
    {
        Debug.Log("本小关完成");
    }
}
