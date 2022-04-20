using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_1_1 : MonoBehaviour
{
    // just for test
    public PuzzleControl_1_1 PuzzleControl_1_1;

    private void OnMouseDown()
    {
        PuzzleControl_1_1.nextScene();
    }
}
