using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScene : UISceneBase
{
    enum Buttons
    {
        StartButton,
        LoadButton,
        SettingButton,
        QuitButton
    }

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton(Buttons.StartButton).gameObject.BindEvent(LoadStartScene);
        GetButton(Buttons.LoadButton).gameObject.BindEvent(LoadSave);
        GetButton(Buttons.SettingButton).gameObject.BindEvent(SettingPopupButtonEvent);
        GetButton(Buttons.QuitButton).gameObject.BindEvent(QuitButtonEvent);
        return true;
    }

    public void LoadStartScene()
    {     
        // 게임시작시 씬 불러오기 전 저장 데이터 삭제
        //Managers.Scene.LoadScene(Defines.SceneType.StartScene);
        gameObject.SetActive(false);
    }

    public void LoadSave()
    {
        //저장본 불러오기
    }

    public void QuitButtonEvent()
    {
        UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로.
    }   

    public void SettingPopupButtonEvent()
    {
        Managers.UI.ShowPopupUI<UISettingPopup>();
    }
}

