using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.UI.Init();
        Managers.Sound.Init();
        Managers.Game.Init();
        Managers.UI.LoadSceneUI<UIStartScene>();
        Managers.Sound.PlayBGM("0_StartScene");
    }

    protected override void OnSceneLoaded()
    {
        
    }

    protected override void OnSceneUnload()
    {

    }
}
