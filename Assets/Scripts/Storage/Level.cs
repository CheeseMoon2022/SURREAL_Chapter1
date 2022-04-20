using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level",menuName = "Chapter/New Level")]
public class Level : ScriptableObject
{
    //关卡信息
    public int level_id;//关卡id
    public int chapter_id;//关卡所属章节
    public Sprite level_pic;//关卡图片（用于章节内关卡切换）
    public bool unlocked;//关卡是否解锁
    public string sceneName;//关卡对应游戏场景

}
