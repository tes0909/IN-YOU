using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.UI.LoadSceneUI<UIStartScene>();
    }

    protected override void OnSceneLoaded()
    {

    }

    protected override void OnSceneUnload()
    {

    }
}
