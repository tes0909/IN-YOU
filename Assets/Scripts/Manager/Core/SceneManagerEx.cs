using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : IManager
{
    public SceneBase CurrentScene => GameObject.FindObjectOfType<SceneBase>(); 
    public int SceneNum => SceneManager.GetActiveScene().buildIndex; 
    private FadeScript fade;

    public static SceneManagerEx Instance { get; private set; }
    public void Init()
    {
        if (Instance == null) Instance = this;
        fade = GameObject.FindObjectOfType<FadeScript>();
    }
    
    public void Clear()
    {

    }

    public void LoadScene(Defines.SceneType sceneType)
    {
        if (sceneType == Defines.SceneType.None)
        {
            Debug.LogWarning("Invalid SceneType");
            return;
        }

        Managers.Clear();
        SceneManager.LoadScene(sceneType.ToString());
    }

    private IEnumerator CorLoadNextScene()
    {
        if (fade == null)
        {
            fade = GameObject.FindObjectOfType<FadeScript>();
        }

        if (fade != null)
        {
            fade.FadeOut();
            yield return new WaitForSeconds(fade.Ftime);
        }
        LoadScene();
    }

    public void LoadNextScene()
    {
        Managers.Instance.StartCoroutine(CorLoadNextScene());
    }


    public void LoadScene()
    {
        int nextSceneNum = SceneNum + 1;
        Managers.Clear();
        SceneManager.LoadScene(nextSceneNum);
        Debug.Log(nextSceneNum);
    }
}
