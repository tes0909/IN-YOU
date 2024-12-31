using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISettingPopup : UIPopupBase
{
    enum Buttons
    {
        CloseButton,
    }

    enum Toggle
    {
        MuteToggle,
    }

    enum Slider
    {
        BGMSlider,
        SFXSlider,
        MasterSlider
    }

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));
        BindToggle(typeof(Toggle));
        BindSlider(typeof(Slider));

        GetButton(Buttons.CloseButton).gameObject.BindEvent(CloseSettingUI);
        GetToggle(Toggle.MuteToggle).gameObject.BindEvent(OnMuteClick);

        GetSlider(Slider.BGMSlider).onValueChanged.AddListener(SetBGMVolume);
        GetSlider(Slider.SFXSlider).onValueChanged.AddListener(SetSFXVolume);
        GetSlider(Slider.MasterSlider).onValueChanged.AddListener(SetMasterVolume);

        Managers.Sound.PrevSoundBgmValue = GetSlider(Slider.BGMSlider).value;
        Managers.Sound.PrevSoundSfxValue = GetSlider(Slider.SFXSlider).value;

        return true;
    }

    public void CloseSettingUI()
    {
        Managers.Game.ResumeGame();
        Close(Defines.UIAnimationType.None);
    }

    public void SetBGMVolume(float value)
    {
        Managers.Sound.SetBGMVolume(value);
    }

    public void SetSFXVolume(float value)
    {
        Managers.Sound.SetSFXVolume(value);
    }

    public void SetMasterVolume(float value)
    {
        Managers.Sound.SetMasterVolume(value);
    }

    // ���Ұ� �̺�Ʈ
    public void OnMuteClick()
    {
        if (Managers.Sound.IsSoundOn)
        {
            // ���� IsSoundOn ���¸� ����
            Managers.Sound.IsSoundOn = false;

            // �� ���� �����̴� �� ����
            GetSlider(Slider.BGMSlider).value = Managers.Sound.PrevSoundBgmValue;
            GetSlider(Slider.SFXSlider).value = Managers.Sound.PrevSoundSfxValue;
            GetSlider(Slider.MasterSlider).value = Managers.Sound.PrevSoundMasterValue;

            // ���� ���� ����
            Managers.Sound.SetBGMVolume(Managers.Sound.PrevSoundBgmValue);
            Managers.Sound.SetSFXVolume(Managers.Sound.PrevSoundSfxValue);
            Managers.Sound.SetMasterVolume(Managers.Sound.PrevSoundMasterValue);
        }
        else
        {
            // ���� �� ����
            Managers.Sound.PrevSoundBgmValue = GetSlider(Slider.BGMSlider).value;
            Managers.Sound.PrevSoundSfxValue = GetSlider(Slider.SFXSlider).value;
            Managers.Sound.PrevSoundMasterValue = GetSlider(Slider.MasterSlider).value;

            // IsSoundOn ���� ����
            Managers.Sound.IsSoundOn = true;

            // �����̴� ���� 0����
            GetSlider(Slider.BGMSlider).value = 0f;
            GetSlider(Slider.SFXSlider).value = 0f;
            GetSlider(Slider.MasterSlider).value = 0f;

            // ���� ���� 0���� ����
            Managers.Sound.SetBGMVolume(0);
            Managers.Sound.SetSFXVolume(0);
            Managers.Sound.SetMasterVolume(0);
        }
    }
}