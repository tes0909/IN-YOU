using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News : SceneBase
{
    protected override void OnSceneLoad()
    {
        Invoke("SetStart", 3f);
    }

    protected override void OnSceneLoaded()
    {
    }

    protected override void OnSceneUnload()
    {
    }
    
    void SetStart()
    {
        DialogueManager.Instance.StartDialogue();
    }
}
