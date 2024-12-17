using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx : IManager
{
    public SceneBase CurrentScene => GameObject.FindObjectOfType<SceneBase>();
    public int SceneNum => SceneManager.GetActiveScene().buildIndex;
    //public int SceneNum  => (int)GameObject.FindObjectOfType<SceneBase>().SceneType - 1;
    private FadeScript fade;

    public void Clear()
    {

    }

    public void Init()
    {
        fade = GameObject.FindObjectOfType<FadeScript>();
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

    public void LoadNextScene()
    {
        int nextSceneNum = SceneNum + 1;
        Managers.Clear();
        SceneManager.LoadScene(nextSceneNum);
        Debug.Log(nextSceneNum);
        if (fade == null)
        {
            fade = GameObject.FindObjectOfType<FadeScript>();
        }
        fade.Fade();
    }
}
