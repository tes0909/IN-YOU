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
        if (instance == null && initialized == false)
        {
            initialized = true;
            instance = FindObjectOfType<Managers>();
            if (instance == null)
            {
                instance = new GameObject($"@Managers").AddComponent<Managers>();
                DontDestroyOnLoad(instance.gameObject);
            }

            //Initialize all managers
            DB?.Init();
            Sound?.Init();
        }
    }

    private DBManager _db = new DBManager();
    private UIManager _ui = new UIManager();
    private SoundManager _sound = new SoundManager();
    private ResourceManager _resource = new ResourceManager();
    private SceneManagerEx _scene = new SceneManagerEx();
    private GameManager _game = new GameManager();

    public static DBManager DB
    {
        get { return Instance?._db; }
    }

    public static UIManager UI
    {
        get { return Instance?._ui; }
    }

    public static SoundManager Sound
    {
        get { return Instance?._sound; }
    }

    public static ResourceManager Resource
    {
        get { return Instance?._resource; }
    }
    
    public static SceneManagerEx Scene
    {
        get { return Instance?._scene; }
    }

    public static GameManager Game
    {
        get { return Instance?._game; }
    }

    public static void Clear()
    {
        UI?.Clear();
        Sound?.Clear();
        Game?.Clear();
    }

}

