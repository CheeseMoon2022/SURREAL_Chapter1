using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawDetect : MonoBehaviour
{
    public GameObject correctJigsaw;
    public GameObject visibleRange;
    // 拼图碎片的检测逻辑

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject == correctJigsaw)
        {
            //检测到碎片时
            visibleRange.SetActive(true);
            correctJigsaw.GetComponent<JigsawDrag>().Fit = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //碎片离开时
        if (collision.gameObject == correctJigsaw)
        {
            visibleRange.SetActive(false);
            correctJigsaw.GetComponent<JigsawDrag>().Fit = false;
        }
            
    }
}
