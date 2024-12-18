using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island_2 : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.Game.CreatePlayer();

        Managers.UI.LoadSceneUI<UIGameScene>();
    }

    protected override void OnSceneLoaded()
    {
        Managers.Sound.PlayBGM("BGM");
        Managers.Sound.SetMasterVolume();
        Managers.Resource.Instantiate("Map/IslandMap");
    }

    protected override void OnSceneUnload()
    {

    }
}
