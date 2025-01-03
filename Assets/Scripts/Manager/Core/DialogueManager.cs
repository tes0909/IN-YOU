using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    
    [SerializeField] private GameObject playerDialoguePanel;

    [SerializeField] private Image playerImage;

    public DialogueData currentDialogueData;
    public DialogueInfo currentDialogueInfo;
    private float DOTextDelay = 1f;
    private int dialogueIndex;
    private bool canTalking = true;
    private string filePath;
    public GameObject disPlay;

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
        playerDialoguePanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        currentDialogueInfo = DataManager.instance.dialogueInfo;
        filePath = "JsonData/";
    }

    public void StartDialogue()
    {
        dialogueIndex = 0;
        playerDialoguePanel.gameObject.SetActive(true);
       
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
        
        if (currentDialogueData.dialogue.Contains("Next Scene"))
        {
            //다음씬으로이동
        }
        
        if (dialogueIndex < currentDialogueInfo.dialogueDatas.Length)
        {
            playerDialogueText.text = string.Empty;

            if (currentDialogueData.DIdx == 9)
            {
                
            }
            
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