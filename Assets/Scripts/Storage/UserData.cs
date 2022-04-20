using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserData:MonoBehaviour
{
    //玩家存档管理
    private static UserData _ins;//单例模式
    public bool isFirst;//是否是第一次进行游戏->判断是否进入引导场景
    public int cur_chapter_id;//当前章节id
    public int cur_level_id;//当前关卡id
    private string path;//存档路径

    public static UserData _Ins
    {
        get
        {
            if (_ins == null)
            {
                // 尝试寻找该类的实例。
                _ins = Object.FindObjectOfType(typeof(UserData)) as UserData;

                if (_ins == null)  // 如果没有找到
                {
                    GameObject obj = new GameObject("UserData"); // 创建一个新的GameObject
                    DontDestroyOnLoad(obj);  // 防止被销毁
                    _ins = obj.AddComponent<UserData>(); // 将实例挂载到GameObject上
                }
            }
            return _ins;
        }
    }

    void Awake()
    {
        if( !_ins )
        {
            _ins = this;
        }
        path = Path.Combine(Application.persistentDataPath, "save.save");
        isFirst = !File.Exists(path);//以存档文件存不存在来判断是否是首次游玩
    }

    public void save()
    {
        //存档
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            writer.Write((byte)cur_chapter_id);
            writer.Write((byte)cur_level_id);
        }
        
    }

    public void load()
    {
        using (BinaryReader reader = new BinaryReader(File.OpenRead(path)))
        {
            cur_chapter_id = reader.ReadByte();
            cur_level_id = reader.ReadByte();
        }
    }

}
