using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu:MonoBehaviour
{
    private static LevelMenu _ins;
    public static GameObject uiPrefab;
    public static LevelMenu _Ins
    {
        get
        {
            if (_ins == null)
            {
                // 尝试寻找该类的实例。
                _ins = Object.FindObjectOfType(typeof(LevelMenu)) as LevelMenu;

                if (_ins == null)  // 如果没有找到
                {
                    uiPrefab = (GameObject)Resources.Load("LevelMenuUI");
                    GameObject obj = Instantiate(uiPrefab);
                    DontDestroyOnLoad(obj);  // 防止被销毁
                    _ins = obj.AddComponent<LevelMenu>(); // 将实例挂载到GameObject上
                }
            }
            return _ins;
        }
    }
    public Chapter chapter;
    public Level level;

    public void updateLevel(Chapter chapter,Level level)
    {
        this.chapter = chapter;
        this.level = level;
    }


}
