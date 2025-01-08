using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public Image image;
    public Image disPlayImage;
    private bool canTalking = true;
    private float DOTextDelay = 1.5f;
    private string filePath = "JsonData/";
    private string NextScene = "Next Scene";
    private string Left = "left";
   
    public void NextDialogue(DialogueInfo currentDialogueInfo)
    {
        // 대화 중 타이핑 방지
        if (!canTalking)
        {
            DialogueText.DOComplete();  
            return;
        }
        
        // 대화 종료
        if (DialogueManager.Instance.dialogueIndex >= currentDialogueInfo.dialogueDatas.Length)
        {
            EndDialogue();
            return;
        }

        DialogueData currentDialogueData = currentDialogueInfo.dialogueDatas[DialogueManager.Instance.dialogueIndex];

        // 대화 출력
        canTalking = false; // 대화 출력전 애니메이션 비활성화, 대화 출력 중 다른 대화로 넘어가는것 방지

        if (currentDialogueData.dialogue.Contains(NextScene))
        {
            DialogueManager.Instance.dialogueIndex++;
            StartCoroutine(LoadNextScene()); 
            return; 
        }
        
        IEnumerator LoadNextScene()
        {
            yield return new WaitForSeconds(0.5f); // Optional delay for smoother transition
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (currentDialogueData.Action == "Hana") disPlayImage.gameObject.SetActive(true);
        else disPlayImage.gameObject.SetActive(false);
        
        if (DialogueManager.Instance.dialogueIndex < currentDialogueInfo.dialogueDatas.Length)
        {
            DialogueText.text = string.Empty;
            
            if (currentDialogueData.position == Left)
            {
                DialogueText.transform.SetAsLastSibling();
            }
            else
            {
                DialogueText.transform.SetAsFirstSibling();
            }
            
            DialogueText.DOText(currentDialogueData.dialogue, DOTextDelay)
                .OnComplete(() => canTalking = true); // 완료시에만 애니메이션 활성화
                
            NameText.text = currentDialogueData.characterName;
            string imagePath = $"{filePath}{currentDialogueData.imageSprite}";
            image.sprite = Resources.Load<Sprite>(imagePath);
            DialogueManager.Instance.dialogueIndex++;
        }
    }
    
    public void EndDialogue()
    {
        DialogueText.text = string.Empty;
        NameText.text = string.Empty;
        canTalking = true; 
        gameObject.SetActive(false);
    }
}
