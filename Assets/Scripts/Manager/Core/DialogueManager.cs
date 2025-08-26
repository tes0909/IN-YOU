using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public DialogueInfo currentDialogueInfo;
    public int dialogueIndex;
    public DialogueUI dialogueUI;
    private FadeScript fade;
    private PlayerController playerController;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator  Start()
    {
        while (DataManager.instance == null || DataManager.instance.dialogueInfo == null)
        {
            yield return null;
        }
        
        currentDialogueInfo = DataManager.instance.dialogueInfo;
    }

    public void StartDialogue()
    {
        if (dialogueUI == null)
        {
            Debug.Log("dialogueui is not ready yet.");
        }
        dialogueUI.gameObject.SetActive(true);
        dialogueUI.NextDialogue(currentDialogueInfo);
        // 첫 대화 출력
        playerController.OnDisable();     
    }

    public void EndDialogue()
    {
        if (dialogueUI == null)
        {
            Debug.Log("dialogueui is not ready yet.");
            return;
        }
        dialogueUI.gameObject.SetActive(false);
        dialogueUI.ClearUI();
        if (playerController != null)
        {
            playerController.OnEnable();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerController = FindObjectOfType<PlayerController>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        if (dialogueUI == null)
        {
            Debug.Log("DialogueUI not found in the new scene.");
        }
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    public bool DialogueActive()
    {
        return dialogueUI != null && dialogueUI.gameObject.activeSelf;
    }
}