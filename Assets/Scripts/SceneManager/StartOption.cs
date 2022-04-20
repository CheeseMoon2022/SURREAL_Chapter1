using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOption : MonoBehaviour
{
    public string guidanceScene, chapterSelectScene;
    // Start is called before the first frame update
    void Start()
    {
        if(UserData._Ins.isFirst)
        {
            SceneManager.LoadSceneAsync(guidanceScene,LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadSceneAsync(chapterSelectScene, LoadSceneMode.Single);
        }
    }

}
