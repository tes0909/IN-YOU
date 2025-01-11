using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IntroScene : SceneBase
{
    protected override void OnSceneLoad()
    {
        Managers.Game.Init();
    }

    protected override void OnSceneLoaded()
    {
    }

    protected override void OnSceneUnload()
    {
    }
}
