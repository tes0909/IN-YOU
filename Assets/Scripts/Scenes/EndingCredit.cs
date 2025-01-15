using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCredit : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.Sound.PlayBGM("12_The Amazing Digital Circus");
    }

    protected override void OnSceneLoaded()
    {
    }

    protected override void OnSceneUnload()
    {
    }
}
