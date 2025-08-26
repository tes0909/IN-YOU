using System;
using UnityEngine;

public interface IManager
{
    void Init();
    void Clear();
}

public class Managers : MonoBehaviour
{
    private static Managers instance;

    public static Managers Instance
    {
        get
        {
            Initialize();
            return instance;
        }
    }

    private static bool initialized = false;
    private static object lockObj = new object();

    private static void Initialize()
    {
        if (instance == null && initialized == false) // instance가 null이거나 초기화 되지 않은 경우 실행
        {
            initialized = true;
            instance = FindObjectOfType<Managers>();
            if (instance == null)
            {
                // managers 객체 동적 생성, 씬 전환 유지
                instance = new GameObject($"@Managers").AddComponent<Managers>();
                DontDestroyOnLoad(instance.gameObject);
            }

            // 각 매니저 초기화
            DB?.Init();
            Resource?.Init();
            Sound?.Init();
        }
    }

    private DBManager _db = new DBManager();
    private UIManager _ui = new UIManager();
    private SoundManager _sound = new SoundManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private GameManager _game = new GameManager();
    
    public static DBManager DB => Instance?._db;

    public static UIManager UI => Instance?._ui;

    public static SoundManager Sound => Instance?._sound;

    public static ResourceManager Resource => Instance?._resource;

    public static SceneManagerEx Scene => Instance?._scene;

    public static GameManager Game => Instance?._game;

    // 매니저 정리 메서드
    public static void Clear()
    {
        UI?.Clear();
        Sound?.Clear();
        Game?.Clear();
    }
}