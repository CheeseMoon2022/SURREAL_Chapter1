using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JigsawDrag : MonoBehaviour
{
    private bool fit = false;
    public Transform destination;
    public Puzzle_Chapter1_1_1 puzzle;
    public bool Fit
    {
        get
        {
            return fit;
        }
        set
        {
            fit = value;
        }
    }

    // 拼图碎片的拖拽逻辑
    private void OnMouseDrag()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        GetComponent<Rigidbody2D>().Sleep();
    }

    private void OnMouseUp()
    {
        if(fit)
        {
            transform.DOMove(destination.position, 1);
            Destroy(GetComponent<Rigidbody2D>());
            puzzle.endFlag += 1;
        }
        else
        {
            GetComponent<Rigidbody2D>().WakeUp();
        }
    }
}
