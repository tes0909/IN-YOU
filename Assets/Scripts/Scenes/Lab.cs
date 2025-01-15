public class Lab : SceneBase
{
    public DialogueUI dialogueUI;

    protected override void OnSceneLoad()
    {  
        Invoke("SetStart", 1.5f);
        Managers.Sound.PlayBGM("5_Laboratory");
    }

    protected override void OnSceneLoaded()
    {
    }

    protected override void OnSceneUnload()
    {
    }

    void SetStart()
    {
        DialogueManager.Instance.dialogueUI = dialogueUI;
        DialogueManager.Instance.StartDialogue();
    }
}
