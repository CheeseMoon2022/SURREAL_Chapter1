using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToChapter1 : SelectChapter
{
    /*
    public override void loadScene()
    {
        //读取用户上一次游玩信息
        UserData._Ins.load();
        if (UserData._Ins.cur_chapter_id == chapter.chapter_id)//判断上一次游玩的是否是该章节
        {
            //若是，则加载上次游玩的关卡
            SceneManager.LoadSceneAsync(chapter.levels[UserData._Ins.cur_level_id].sceneName, LoadSceneMode.Single);
        }
        else
        {
            //若不是，则加载该章节第一关
            SceneManager.LoadSceneAsync(chapter.levels[0].sceneName, LoadSceneMode.Single);
            //更新存档
            saveUpdate();
        }
    }

    public override void saveUpdate()
    {
        //更新存档
        UserData._Ins.cur_chapter_id = chapter.chapter_id;
        UserData._Ins.cur_level_id = 0;
    }
    */
}
