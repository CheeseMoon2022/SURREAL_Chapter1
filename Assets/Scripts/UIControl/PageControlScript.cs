using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    //该脚本用于在章节选择中控制左右翻页的逻辑
    //public int pageNum = 3;
    public List<GameObject> pageList;
    public ChapterSelect_Camera camera;
    public GameObject leftBtn;
    public GameObject rightBtn;
    private int pageNum;
    private int curPage;
    private void Start()
    {
        pageNum = pageList.Count;
        //Debug.Log(pageNum);
        curPage = 0;
    }

    public void leftPage()
   {
        //左翻页
        //Debug.Log("left");
        if (curPage == 0)
        {
            //在第一页，无法向左
            return;
        }
        else
        {
            curPage--;
            setBtnActive();
            camera.cameraMove(pageList[curPage].transform.position);
           
        }
   }

    public void rightPage()
    {
        //右翻页
        //Debug.Log("right");
        if (curPage == pageNum-1)
        {
            //在最后一页，无法向右
            return;
        }
        else
        {
            curPage++;
            setBtnActive();
            camera.cameraMove(pageList[curPage].transform.position);
            
        }
        
    }

    private void setBtnActive()
    {
        //左右按钮的开启和关闭逻辑
        if (curPage == 0)
        {
            leftBtn.SetActive(false);
        }
        else if(curPage == pageNum-1)
        {
            rightBtn.SetActive(false);
        }
        else
        {
            rightBtn.SetActive(true);
            leftBtn.SetActive(true);
        }
    }


}
