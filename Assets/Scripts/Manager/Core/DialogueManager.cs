using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerDialogueText;
    
    public GameObject playerDialoguePanel;
    public GameObject dialoguePrefab;

    public Image playerImage;

    public DialogueData currentDialogueData;
    public DialogueInfo currentDialogueInfo;
    private float DOTextDelay = 1.5f;
    private int dialogueIndex;
    private bool canTalking = true;
    private string filePath;
    // public Image disPlayImage;

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
        dialoguePrefab.gameObject.SetActive(false);
    }

    private void Start()
    {
        currentDialogueInfo = DataManager.instance.dialogueInfo;
        filePath = "JsonData/";
    }

    public void StartDialogue()
    {
        dialoguePrefab.gameObject.SetActive(true);
       
        // 첫 대화 출력
        NextDialogue();
    }

    public void NextDialogue()
    {
        // 대화 중 타이핑 방지
        if (!canTalking)
        {
            playerDialogueText.DOComplete();
            return;
        }
        
        // 대화 종료
        if (dialogueIndex >= currentDialogueInfo.dialogueDatas.Length)
        {
            EndDialogue();
            return;
        }

        currentDialogueData = currentDialogueInfo.dialogueDatas[dialogueIndex];

        // 대화 출력
        canTalking = false; // 대화 출력전 애니메이션 비활성화, 대화 출력 중 다른 대화로 넘어가는것 방지

        switch (currentDialogueData.uiType)
        {
            case "News":
            case "letter":
            case "Lab":
                LoadUI();
                break;
        }
        
        if (currentDialogueData.dialogue.Contains("Next Scene"))
        {
            dialogueIndex++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        // if (currentDialogueData.DIdx == 8) disPlayImage.gameObject.SetActive(true);
        // else disPlayImage.gameObject.SetActive(false);
        
        if (dialogueIndex < currentDialogueInfo.dialogueDatas.Length)
        {
            playerDialogueText.text = string.Empty;
            
            if (currentDialogueData.position == "left")
            {
                playerDialogueText.transform.SetAsLastSibling();
            }
            else
            {
                playerDialogueText.transform.SetAsFirstSibling();
            }
            
            playerDialogueText.DOText(currentDialogueData.dialogue, DOTextDelay)
                .OnComplete(() => canTalking = true); // 완료시에만 애니메이션 활성화
                
            playerNameText.text = currentDialogueData.characterName;
            string imagePath = $"{filePath}{currentDialogueData.imageSprite}";
            playerImage.sprite = Resources.Load<Sprite>(imagePath);
            dialogueIndex++;
        }
    }

    public void LoadUI()
    {
        if (dialoguePrefab != null)
        {
            Destroy(dialoguePrefab);
        }
        GameObject uiPrefab = Resources.Load<GameObject>($"Prefabs/UI/DialogueUI/{currentDialogueData.uiType}");
        if (uiPrefab != null) // 기존 로드된게 있으면
        {
            dialoguePrefab = Instantiate(uiPrefab, transform);
        }
    }
    
    public void EndDialogue()
    {
        playerDialogueText.text = string.Empty;
        playerNameText.text = string.Empty;
        canTalking = true; 
        playerDialoguePanel.gameObject.SetActive(false);
    }
    
    public bool DialogueActive()
    {
        return playerDialoguePanel.activeSelf;
    }
}