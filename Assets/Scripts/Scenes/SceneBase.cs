using UnityEngine;

public abstract class SceneBase : MonoBehaviour
{
    [SerializeField] private Defines.SceneType sceneType = Defines.SceneType.None;
    public Defines.SceneType SceneType => sceneType;

    private void Start()
    {
        OnSceneLoad();
        OnSceneLoaded();
    }
    private void OnDestroy()
    {
        OnSceneUnload();
    }
    protected abstract void OnSceneLoad();
    protected abstract void OnSceneLoaded();
    protected abstract void OnSceneUnload();
}