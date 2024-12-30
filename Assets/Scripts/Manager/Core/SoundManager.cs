using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : IManager
{
    // SFX(효과음) 오디오 클립들을 저장하는 딕셔너리
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    
    // BGM(배경음악) 오디오 클립들을 저장하는 딕셔너리
    private Dictionary<string, AudioClip> bgmClips = new Dictionary<string, AudioClip>();

    private AudioSource _bgmSource;
    public AudioSource BgmSource
    {
        get
        {
            if (_bgmSource == null)
            {
                // BGM 재생용 GameObject 생성
                GameObject bgmSourceObject = new GameObject { name = "@BGM" };
                _bgmSource = bgmSourceObject.AddComponent<AudioSource>();
                
                // AudioMixer의 BGM 그룹 연결
                _bgmSource.outputAudioMixerGroup = masterMixer?.FindMatchingGroups("BGM")[0];
                
                _bgmSource.loop = true;
                Object.DontDestroyOnLoad(bgmSourceObject);
            }
            return _bgmSource;
        }
    }

    private AudioSourcePool audioSourcePool;

    private AudioMixer masterMixer;

    private int defaultCapacity = 10;
    private int maxSize = 20;

    private bool initialized; // 초기화 상태 확인

    protected bool isSoundOn;
    protected float prevSoundSfxValue;
    protected float prevSoundBgmValue;
    protected float prevSoundMasterValue;

    public bool IsSoundOn
    {
        get { return isSoundOn; }
        set { isSoundOn = value; }
    }

    public float PrevSoundSfxValue
    {
        get { return prevSoundSfxValue; }
        set { prevSoundSfxValue = value; }
    }

    public float PrevSoundBgmValue
    {
        get { return prevSoundBgmValue; }
        set { prevSoundBgmValue = value; }
    }

    public float PrevSoundMasterValue
    {
        get { return prevSoundMasterValue; }
        set { prevSoundMasterValue = value; }
    }

    // 사운드 매니저 초기화
    public void Init()
    {
        if (initialized) return;

        initialized = true;
        
        // 오디오 믹서 로드
        masterMixer = Managers.Resource.Load<AudioMixer>("Sounds/MasterMixer");
       
        // BGM 클립 로드 및 추가
        AudioClip[] bgms = Managers.Resource.LoadAll<AudioClip>("Sounds/BGM");
        foreach (var clip in bgms)
            bgmClips.Add(clip.name, clip);
        Debug.Log($"BGM Loaded Count : {bgmClips.Count}");

        // SFX 클립 로드 및 추가
        AudioClip[] sfxs = Managers.Resource.LoadAll<AudioClip>("Sounds/SFX");
        foreach (var clip in sfxs)
            sfxClips.Add(clip.name, clip);
        Debug.Log($"SFX Loaded Count : {sfxClips.Count}");

        // AudioSourcePool 초기화
        var sfxGroup = masterMixer?.FindMatchingGroups("SFX")[0];
        audioSourcePool = new AudioSourcePool(
            masterMixerGroup: sfxGroup,
            defaultCapacity: defaultCapacity,
            maxSize: maxSize
        );

        PrevSoundSfxValue = 1f;
        prevSoundBgmValue = 1f;
        prevSoundMasterValue = 1f;
    }
    public void Clear()
    {
        audioSourcePool?.Clear();
    }

    // SFX 재생
    public void PlaySFX(string name, Vector3 position)
    {
        if (sfxClips.TryGetValue(name, out AudioClip clip))
        {
            AudioSource source = audioSourcePool.Pop();
            source.transform.position = position;
            source.clip = clip;
            source.Play();

            // ���尡 ������ ��ȯ
            //Managers.Coroutine.StartCoroutine(name, ReturnSourceWhenFinished(source, clip.length));
        }
        else
        {
            Debug.LogWarning($"SFX '{name}' not found!");
        }
    }

    private IEnumerator ReturnSourceWhenFinished(AudioSource source, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSourcePool.Push(source);
    }

    // BGM 재생
    public void PlayBGM(string name)
    {
        if (bgmClips.TryGetValue(name, out AudioClip clip))
        {
            BgmSource.clip = clip;
            BgmSource.Play();
        }
        else
        {
            Debug.LogWarning($"BGM '{name}' not found!");
        }
    }

    public void StopBGM()
    {
        BgmSource.Stop();
    }

    // SFX 볼륨 조절
    public void SetSFXVolume()
    {
        if (masterMixer == null) return;
        masterMixer.SetFloat("SFX", LinearToDecibel(prevSoundSfxValue));
    }

    public void SetSFXVolume(float volume)
    {
        if (masterMixer == null) return;
        masterMixer.SetFloat("SFX", LinearToDecibel(volume));
    }

    // BGM 볼륨 조절
    public void SetBGMVolume()
    {
        if (masterMixer == null) return;
        masterMixer.SetFloat("BGM", LinearToDecibel(prevSoundBgmValue));
    }

    public void SetBGMVolume(float volume)
    {
        if (masterMixer == null) return;
        masterMixer.SetFloat("BGM", LinearToDecibel(volume));
    }

    // Master 볼륨 조절
    public void SetMasterVolume(float volume)
    {
        if (masterMixer == null) return;
        masterMixer.SetFloat("Master", LinearToDecibel(volume));
    }

    public void SetMasterVolume()
    {
        if (masterMixer == null) return;

        Debug.Log(prevSoundMasterValue);
        masterMixer.SetFloat("Master", LinearToDecibel(prevSoundMasterValue));
    }

    private float LinearToDecibel(float linear)
    {
        float dB;
        if (linear != 0)
            dB = 20f * Mathf.Log10(linear);
        else
            dB = -80f; // 음소거 상태
        return dB;
    }

    public void TransitionToSnapshot(string snapshotName, float transitionTime)
    {
        AudioMixerSnapshot snapshot = masterMixer.FindSnapshot(snapshotName);
        if (snapshot != null)
        {
            snapshot.TransitionTo(transitionTime);
        }
        else
        {
            Debug.LogWarning($"Snapshot '{snapshotName}' not found!");
        }
    }
}