using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFlag
{
    // 用于检测在章节选择场景中是否可以进行点击
    private static ClickFlag _instance = null;
    private bool canClick;
    public bool CanClick
    {
        get
        {
            return canClick;
        }
        set
        {
            canClick = value;
        }
    }
    private ClickFlag()
    {
        canClick = false;
    }

    public static ClickFlag GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ClickFlag();
        }
        return _instance;
    }
    
}
