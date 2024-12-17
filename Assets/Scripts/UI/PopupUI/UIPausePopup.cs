using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIPausePopup : UIPopupBase
{
    public GameObject EscUI;

    private bool isPaused = false; // 일시정지 상태인지

    enum Buttons
    {
        Resume,
        Setting,
        Save,
        Load,
        Quit,
    }

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton(Buttons.Resume).gameObject.BindEvent(TogglePauseMenu);
        GetButton(Buttons.Setting).gameObject.BindEvent(SettingMenu);
        GetButton(Buttons.Save).gameObject.BindEvent(SaveCurrentCondition);
        GetButton(Buttons.Load).gameObject.BindEvent(LoadSave);
        GetButton(Buttons.Quit).gameObject.BindEvent(GoToStartScene);

        return true;
    }

    public override void Open(Defines.UIAnimationType type = Defines.UIAnimationType.None)
    {
        base.Open(type);
        Managers.Game.StopGame();
    }

    private void Start()
    {
        if (EscUI != null)
        {
            EscUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            TogglePauseMenu();
        }
    }
    
    public void TogglePauseMenu() // UI 활성, 비활성
    {
        isPaused = !isPaused;

        if (EscUI != null)
        {
            EscUI.SetActive(isPaused);
        }

        Time.timeScale = isPaused ? 0f : 1f; // 시간 일시정지, 복구
    }

    public void SettingMenu()
    {
        Managers.UI.ShowPopupUI<UISettingPopup>();
    }

    public void SaveCurrentCondition()
    {
        Managers.Game.SaveGame();
    }

    public void LoadSave()
    {
        Managers.Game.LoadGame();
    }

    public void GoToStartScene()
    {
        Managers.Scene.LoadScene(Defines.SceneType.StartScene);
    }
    // 각자 함수들을 버튼에 할당 해주기, EventSystem 확인 할 것
}
