using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChapter1 : ObjInteract
{
    // 
    public string sceneName;
    private AsyncOperation async = null;
    private void OnMouseDown()
    {
        if(ClickFlag.GetInstance().CanClick)
        {
            //加载关卡1
            StartCoroutine("LoadScene");
        }

    }

    IEnumerator LoadScene()
    {
        async = Application.LoadLevelAsync(sceneName);
        yield return async;
    }

}
