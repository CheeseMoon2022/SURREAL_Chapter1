using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChickenDrag : MonoBehaviour
{
    private bool fit = false;
    public GameObject oven;
    public Transform endPoint;
    public Vector3 startPoint;
    public Puzzle_Chapter1_1_3 Puzzle;

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
    }

    private void OnMouseUp()
    {
        if (fit)
        {
            transform.DOMove(endPoint.position, 1);
            Invoke("chickenEnd", 1);
        }
        else
        {
            transform.DOMove(startPoint,1);
            this.GetComponent<SpriteRenderer>().rendererPriority = 12;
        }
    }

    private void chickenEnd()
    {
        //this.GetComponent<SpriteRenderer>().rendererPriority = 10;
        //oven.GetComponent<OvenDetect>().ovenClose();
        Destroy(oven.GetComponent<OvenDetect>());
        Destroy(this.GetComponent<ChickenDrag>());
        Puzzle.endFlag = true;
    }


}
