using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class ToChapterSelect : MonoBehaviour
{
    public PlayableDirector director;
    public string sceneName;
    private AsyncOperation async = null;
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
            //
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
            StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        async = Application.LoadLevelAsync(sceneName);
        yield return async;
    }



}
