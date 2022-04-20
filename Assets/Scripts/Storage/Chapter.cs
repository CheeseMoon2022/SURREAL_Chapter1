using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "New Chapter", menuName = "Chapter/New Chapter")]
public class Chapter : ScriptableObject
{
    //章节信息
    public int chapter_id;//章节id
    public string title;//章节标题
    [TextArea]
    public string description;//章节描述
    public bool unlocked;//章节是否解锁
    public Level[] levels;//章节关卡组
}
