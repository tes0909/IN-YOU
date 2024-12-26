using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource backgroundMusic;
    public AudioClip[] backgroundMusicLists;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        for (int i = 0; i < backgroundMusicLists.Length; i++)
        {
            if (scene.name == backgroundMusicLists[i].name)
            {
                PlayBackgroundSound(backgroundMusicLists[i]);
            }
            else
            {
                Debug.Log("씬 이름이 맞지 않거나 해당씬에 맞는 bgm 할당이 되지 않았습니다.");
            }
        }
    }

    public void PlaySfxSound(string sfxName, AudioClip clip)
    {
        GameObject audio = new GameObject(sfxName + "Sound");
        AudioSource audioSource = audio.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
        
        Destroy(audio, clip.length);
    }

    

}
