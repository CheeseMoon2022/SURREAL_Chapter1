using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Back_Quit
{
    private static Back_Quit _ins;
    public static Back_Quit _Ins 
    { get
        {
            if(_ins == null)
            {
                _ins = new Back_Quit();
            }
            return _ins;
        }
    }

    public void exit()
    {
        #if UNITY_EDITOR    //在编辑器模式下
            EditorApplication.isPlaying = false;
        #else //游戏运行时
            Application.Quit();
        #endif
    }

    public void backToChapterSelect()
    {
        SceneManager.LoadSceneAsync("Scenes/ChapterSelectScene", LoadSceneMode.Single);
        //调整相机至退出章节处
    }
}
