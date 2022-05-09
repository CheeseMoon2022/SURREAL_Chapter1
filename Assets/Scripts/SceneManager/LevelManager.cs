using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    // 
    private static LevelManager _ins;
    public Level level;
    public Chapter chapter;
    public static LevelManager _Ins 
    { get 
        {
            if (_ins == null)
            {
                _ins = new LevelManager();
            }
            return _ins;
        } 
    }

    public void loadScene()
    {
        //加载场景
        saveUpdate();
        SceneManager.LoadScene(level.sceneName, LoadSceneMode.Single);
    }

    public void saveUpdate()
    {
        //更新存档
        UserData._Ins.cur_chapter_id = level.chapter_id;
        UserData._Ins.cur_level_id = level.level_id;
        UserData._Ins.save();
        //更新levelMenu
        LevelMenu._Ins.chapter = chapter;
        LevelMenu._Ins.level = level;
    }
}
