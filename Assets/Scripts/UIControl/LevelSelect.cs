using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //public LevelMenu levelMenu;
    public GameObject leftBtn, rightBtn;//左右翻页按钮
    public Image page1, page2, page3;//三个页面
    public Sprite nullSprite;
    private RectTransform[] pages;//记录三个页面的rectTransform信息
    private Vector3[] pos = new Vector3[3];
    private Vector2[] sizes = new Vector2[3];
    private Chapter chapter;
    private Level level;
    private int index;
    private bool clickable;

    void Awake()
    {
        chapter = LevelMenu._Ins.chapter;
        level = LevelMenu._Ins.level;
        index = level.level_id;
        clickable = true;
        //
        pages = new RectTransform[3];
        pages[0] = page1.rectTransform;
        pos[0] = new Vector3(pages[0].position.x, pages[0].position.y, pages[0].position.z);
        sizes[0] = new Vector2(pages[0].sizeDelta.x, pages[0].sizeDelta.y);
        pages[1] = page2.rectTransform;
        pos[1] = new Vector3(pages[1].position.x, pages[1].position.y, pages[1].position.z);
        sizes[1] = new Vector2(pages[1].sizeDelta.x, pages[1].sizeDelta.y);
        pages[2] = page3.rectTransform;
        pos[2] = new Vector3(pages[2].position.x, pages[2].position.y, pages[2].position.z);
        sizes[2] = new Vector2(pages[2].sizeDelta.x, pages[2].sizeDelta.y);
        //初始显示图片
        switchLevelPic();
        showUnlocked();
    }

    private void OnEnable()
    {
        //每次激活时初始化
        chapter = LevelMenu._Ins.chapter;
        level = LevelMenu._Ins.level;
        index = level.level_id;
        switchLevelPic();
        showUnlocked();
    }

    private void switchLevelPic()
    {
        if (index == 0)
        {
            page1.sprite = nullSprite;
            page2.sprite = chapter.levels[index].level_pic;
            page3.sprite = chapter.levels[index + 1].level_pic;
        }
        else if (index == chapter.levels.Length - 1)
        {
            page1.sprite = chapter.levels[index - 1].level_pic;
            page2.sprite = chapter.levels[index].level_pic;
            page3.sprite = nullSprite;
        }
        else
        {
            page1.sprite = chapter.levels[index - 1].level_pic;
            page2.sprite = chapter.levels[index].level_pic;
            page3.sprite = chapter.levels[index + 1].level_pic;
        }

    }

    private void showUnlocked()
    {
        //判断是否有章节上锁，若上锁，则显示上锁蒙版
        if (index > 0 && !chapter.levels[index - 1].unlocked)
        {
            page1.transform.GetChild(0).gameObject.SetActive(true);
        }else
        {
            page1.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (!chapter.levels[index].unlocked)
        {
            page2.transform.GetChild(0).gameObject.SetActive(true);
        }else
        {
            page2.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (index < chapter.levels.Length - 1 && !chapter.levels[index + 1].unlocked)
        {
            page3.transform.GetChild(0).gameObject.SetActive(true);
        }else
        {
            page3.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    public void leftPage()
    {
        if(index > 0)
        {
            //向左翻
            //翻页时无法点击
            clickable = false;

            //效果：page1到page2的位置，page2到page3的位置，page3读取，并到page1的位置；
            page1.rectTransform.DOMove(pos[1], 1);
            page1.rectTransform.DOSizeDelta(sizes[1], 1);
            page2.rectTransform.DOMove(pos[2], 1);
            page2.rectTransform.DOSizeDelta(sizes[2], 1);
            page3.rectTransform.DOMove(pos[0], 1);
            page3.rectTransform.DOSizeDelta(sizes[0], 1);

            //进行置顶顺序的调整，顺序为page1、page2、page3
            page3.transform.SetAsLastSibling();
            page2.transform.SetAsLastSibling();
            page1.transform.SetAsLastSibling();

            //调整循环
            Image temp = page3;
            page3 = page2;
            page2 = page1;
            page1 = temp;

            //调整index
            index--;

            //切换关卡图片
            switchLevelPic();

            //显示上锁状态
            showUnlocked();

            //1s后激活clickable
            Invoke("activeClickable", 1);
        }
    }

    public void rightPage()
    {
        if(index < chapter.levels.Length-1)
        {
            //向右翻
            //翻页时无法点击
            clickable = false;

            //效果：page2到page1的位置，page3到page2的位置，page1读取，并到page3的位置；
            page2.rectTransform.DOMove(pos[0], 1);
            page2.rectTransform.DOSizeDelta(sizes[0], 1);
            page3.rectTransform.DOMove(pos[1], 1);
            page3.rectTransform.DOSizeDelta(sizes[1], 1);
            page1.rectTransform.DOMove(pos[2], 1);
            page1.rectTransform.DOSizeDelta(sizes[2], 1);

            //进行置顶顺序的调整，顺序为page3、page2、page1
            page1.transform.SetAsLastSibling();
            page2.transform.SetAsLastSibling();
            page3.transform.SetAsLastSibling();

            //调整循环
            Image temp = page1;
            page1 = page2;
            page2 = page3;
            page3 = temp;

            //调整index
            index++;

            //切换关卡图片
            switchLevelPic();

            //显示上锁状态
            showUnlocked();

            //1s后激活clickable
            Invoke("activeClickable", 1);
        }
        
    }

    private void activeClickable()
    {
        clickable = true;
    }


    public void selectLevel_click()
    {
        //点击时判断是否能切换场景
        if(clickable)
        {
            if (chapter.levels[index].unlocked)
            {
                if(index != level.level_id)
                {
                    LevelManager._Ins.level = chapter.levels[index];
                    LevelManager._Ins.loadScene();
                    //SceneManager.LoadScene(chapter.levels[index].sceneName, LoadSceneMode.Single);
                }
                //关闭panel
                this.gameObject.SetActive(false);
            }

        }
    }


}
