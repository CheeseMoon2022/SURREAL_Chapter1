using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectChapter : MonoBehaviour
{
    // 
    public Chapter chapter;
    private void OnMouseDown()
    {
        if (chapter.unlocked && ClickFlag.GetInstance().CanClick)
        {
            //加载关卡
            loadScene();
        }
    }

    public virtual void loadScene()
    {
        //读取用户上一次游玩信息
        UserData._Ins.load();
        if (UserData._Ins.cur_chapter_id == chapter.chapter_id)//判断上一次游玩的是否是该章节
        {
            //若是，则加载上次游玩的关卡
            SceneManager.LoadSceneAsync(chapter.levels[UserData._Ins.cur_level_id].sceneName, LoadSceneMode.Single);
            //给关卡ui赋值
            LevelMenu._Ins.chapter = chapter;
            LevelMenu._Ins.level = chapter.levels[UserData._Ins.cur_level_id];
            //给levelManager赋值
            LevelManager._Ins.chapter = chapter;
            LevelManager._Ins.level = chapter.levels[UserData._Ins.cur_level_id];
        }
        else
        {
            //若不是，则加载该章节第一关
            SceneManager.LoadSceneAsync(chapter.levels[0].sceneName, LoadSceneMode.Single);
            //给关卡ui赋值
            LevelMenu._Ins.chapter = chapter;
            LevelMenu._Ins.level = chapter.levels[0];
            //给levelManager赋值
            LevelManager._Ins.chapter = chapter;
            LevelManager._Ins.level = chapter.levels[0];
            //更新存档
            saveUpdate();
        }
    }

    public virtual void saveUpdate()
    {
        //更新存档
        UserData._Ins.cur_chapter_id = chapter.chapter_id;
        UserData._Ins.cur_level_id = 0;
        UserData._Ins.save();
    }

}
