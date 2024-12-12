using System.Timers;
using TMPro;
using UnityEngine;

public class UIGameScene : UISceneBase
{
    enum Objects
    {
        HealthBar,
    }

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        Bind<GameObject>(typeof(Objects));

        return true;
    }

    public void HideUI()
    {
        GetObject(Objects.HealthBar).SetActive(false);
    }

    public void ShowUI()
    {
        GetObject(Objects.HealthBar).SetActive(true);
    }
}