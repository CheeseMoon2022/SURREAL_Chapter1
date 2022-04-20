using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    //public LevelMenu levelMenu;

    public void returnBack()
    {
        //更新存档
        UserData._Ins.cur_chapter_id = LevelMenu._Ins.chapter.chapter_id;
        UserData._Ins.cur_level_id = LevelMenu._Ins.level.level_id;
        UserData._Ins.save();
        //返回主菜单
        SceneManager.LoadScene("Scenes/ChapterSelectScene", LoadSceneMode.Single);
        //销毁levelMenu
        Destroy(LevelMenu._Ins.gameObject);
    }
}
