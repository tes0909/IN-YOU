using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameText;
    public Image image;
    public Image disPlayImage;
    public bool typing; // 텍스트 출력 중 여부
    private float DOTextDelay = 1.5f;
    private readonly string filePath = "JsonData/";
    private readonly string nextScene = "Next Scene";
    private readonly string left = "left";
    private readonly string Hana = "Hana";
   
    public void NextDialogue(DialogueInfo currentDialogueInfo)
    {
        // 텍스트 출력 중 애니메이션 완료 후 반환
        if (typing)
        {
            DialogueText.DOComplete(); // 애니메이션 즉시 완료
            typing = false;
            return;
        }
        
        // 대화 종료(인덱스 길이 초과시)
        if (DialogueManager.Instance.dialogueIndex >= currentDialogueInfo.dialogueDatas.Length)
        {
            EndDialogue();
            return;
        }
        
        // 대화데이터 로드 및 인덱스 증가
        DialogueData currentDialogueData = currentDialogueInfo.dialogueDatas[DialogueManager.Instance.dialogueIndex];
        DialogueManager.Instance.dialogueIndex++;
        
        // 텍스트 출력
        DialogueText.text = string.Empty;
        typing = true; // 출력 상태

        if (currentDialogueData.dialogue.Contains(nextScene))
        {
            DialogueManager.Instance.dialogueIndex++;
            Managers.Scene.LoadNextScene();
            return; 
        }

        if (currentDialogueData.dialogue.Contains("Later Scene"))
        {
            DialogueManager.Instance.dialogueIndex++;
            Managers.Scene.LoadLaterScene();
            return; 
        }

        if (currentDialogueData.specialAction == "FadeIn")
        {
            FadeScript fade = FindObjectOfType<FadeScript>();
            fade.FadeIn();
        }
        
        if (currentDialogueData.specialAction == "FadeBlue")
        {
            FadeScript fade = FindObjectOfType<FadeScript>();
            fade.FadeBlue();
        }
        
        if (currentDialogueData.PortalAction == "Portal")
        {
            PortalForDemo portalForDemo = FindObjectOfType<PortalForDemo>();
            PortalFadeOut portalFadeOut = FindObjectOfType<PortalFadeOut>();
            if (portalForDemo != null)
            {
                SpriteRenderer portalRenderer = portalForDemo.GetComponent<SpriteRenderer>();
                portalRenderer.enabled = true;
            }

            if (portalFadeOut != null)
            {
                SpriteRenderer portalRenderer = portalFadeOut.GetComponent<SpriteRenderer>();
                portalRenderer.enabled = true;
            }
        }

        if (currentDialogueData.specialAction == Hana)
            disPlayImage.gameObject.SetActive(true);
        else 
            disPlayImage.gameObject.SetActive(false);
        
        if (currentDialogueData.position == left)
        {
            DialogueText.transform.SetAsLastSibling();
        }
        else
        {
            DialogueText.transform.SetAsFirstSibling();
        }   

        DialogueText.DOText(currentDialogueData.dialogue, DOTextDelay)
            .OnComplete(() => typing = false); // 완료시에만 애니메이션 활성화    
        
        // 캐릭터 이름, 이미지 로드
        NameText.text = currentDialogueData.characterName;
        string imagePath = $"{filePath}{currentDialogueData.imageSprite}";
        image.sprite = Resources.Load<Sprite>(imagePath);    
    }
    
    public void EndDialogue()
    {
        DialogueText.text = string.Empty;
        NameText.text = string.Empty;
        gameObject.SetActive(false);
    }
}
