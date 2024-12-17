using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_1 : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.UI.Init();
        Managers.Sound.Init();
        Managers.Game.Init();

        Managers.UI.LoadSceneUI<UIGameScene>();
    }

    protected override void OnSceneLoaded()
    {
        Managers.Sound.PlayBGM("BGM");
        Managers.Sound.SetMasterVolume();
        Managers.Resource.Instantiate("Map/Isaland_1");
    }

    protected override void OnSceneUnload()
    {

    }
}
