using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;


public class ToChapterSelect : MonoBehaviour
{
    public PlayableDirector director;
    public string sceneName;

    void OnEnable()
    {
        director.stopped += OnPlayableDirectorStopped;
    }
    void OnDisable()
    {
        director.stopped -= OnPlayableDirectorStopped;
    }
    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (aDirector == director)
        {
            //Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
            SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
            //存档
            UserData._Ins.cur_chapter_id = 0;
            UserData._Ins.cur_level_id = 0;
            UserData._Ins.save();
        }
    }

}
