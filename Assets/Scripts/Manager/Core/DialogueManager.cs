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

    [SerializeField] private Image npcImage;

    public DialogueData currentDialogueData;
    public DialogueInfo currentDialogueInfo;
    private float DOTextDelay = 1f;
    private int dialogueIndex;
    private bool canTalking = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        playerDialoguePanel.gameObject.SetActive(false);
    }

    public void StartDialogue(DialogueData dialogueData)
    {
        currentDialogueData = dialogueData;
        dialogueIndex = 0;
        playerDialoguePanel.SetActive(true);

        npcImage.sprite = Resources.Load<Sprite>(currentDialogueData.imageSprite);
       
        // 첫 대화 출력
        NextDialogue();
    }

    public void NextDialogue()
    {
        // 타이핑중
        if (!canTalking)
        {
            playerDialogueText.DOComplete();
            return;
        }
        
        // 대화 종료
        if (dialogueIndex >= currentDialogueInfo.DialogueDatas.Length)
        {
            EndDialogue();
            return;
        }

        // 대화 출력
        canTalking = false; // 대화 출력전 애니메이션 비활성화, 대화 출력 중 다른 대화로 넘어가는것 방지
        

        if (currentDialogueData.dialogue[dialogueIndex].Contains("Next Scene"))
        {
            
        }
        
        if (currentDialogueData.dialogue[dialogueIndex].Contains("Next Scene"))
        {
            //다음씬으로이동
        }
        
        if (dialogueIndex < currentDialogueData.dialogue.Length)
        {
            playerDialogueText.text = string.Empty;
            playerDialogueText.DOText(currentDialogueData.dialogue[dialogueIndex], DOTextDelay)
                .OnComplete(() => canTalking = true); // 완료시에만 애니메이션 활성화
                
            playerNameText.text = currentDialogueData.characterName[dialogueIndex];
            
            playerDialogueText.transform.SetAsFirstSibling();
            dialogueIndex++;
        }
        
        else if (dialogueIndex < currentDialogueData.dialogue.Length)
        {
            playerDialogueText.text = string.Empty;
            playerDialogueText.DOText(currentDialogueData.dialogue[dialogueIndex], DOTextDelay)
                .OnComplete(() => canTalking = true); // 완료시에만 애니메이션 활성화

            playerNameText.text = currentDialogueData.characterName[dialogueIndex];
                
            playerDialogueText.transform.SetAsLastSibling();
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