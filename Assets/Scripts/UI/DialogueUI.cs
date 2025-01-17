using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.Rendering.Universal;
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
    private const string JsonFilePath = "JsonData/";
    private const string NextSceneAction = "Next Scene";
    private const string LaterSceneAction = "Later Scene";
    private const string PositionLeft = "left";
    private const string SpecialActionFadeIn = "FadeIn";
    private const string SpecialActionFadeBlue = "FadeBlue";
    private const string SpecialActionPortal = "Portal";
    private const string ActionEnd = "End";
    private const string CharacterHana = "Hana";
   
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
            ClearUI();
            return;
        }
        
        // 대화 데이터, 인덱스 증가
        DialogueData currentDialogueData = currentDialogueInfo.dialogueDatas[DialogueManager.Instance.dialogueIndex];
        DialogueManager.Instance.dialogueIndex++;

        if (currentDialogueData.dialogue.Contains(NextSceneAction))
        {
            Managers.Scene.LoadNextScene();
            return; 
        }

        if (currentDialogueData.dialogue.Contains(LaterSceneAction))
        {
            Managers.Scene.LoadLaterScene();
            return; 
        }

        if (currentDialogueData.specialAction == SpecialActionFadeIn)
        {
            FadeScript fade = FindObjectOfType<FadeScript>();
            fade.FadeIn();
        }
        
        if (currentDialogueData.specialAction == SpecialActionFadeBlue)
        {
            FadeScript fade = FindObjectOfType<FadeScript>();
            fade.FadeBlue();
            Light2D[] light2Ds = FindObjectsOfType<Light2D>();
            foreach (Light2D light2D in light2Ds)
            {
                light2D.enabled = true;
            }
        }
        
        if (currentDialogueData.PortalAction == SpecialActionPortal)
        {
            PortalForDemo portalForDemo = FindObjectOfType<PortalForDemo>();
            PortalFadeOut portalFadeOut = FindObjectOfType<PortalFadeOut>();
            if (portalForDemo != null)
            {
                SpriteRenderer portalRenderer = portalForDemo.GetComponent<SpriteRenderer>();
                portalRenderer.enabled = true;
                
                BoxCollider2D boxCollider2D = portalForDemo.GetComponent<BoxCollider2D>();
                boxCollider2D.enabled = true;
            }

            if (portalFadeOut != null)
            {
                SpriteRenderer portalRenderer = portalFadeOut.GetComponent<SpriteRenderer>();
                portalRenderer.enabled = true;
            }
        }
        // 텍스트 출력
        DialogueText.text = string.Empty;
        typing = true; // 출력 상태

        disPlayImage.gameObject.SetActive(currentDialogueData.specialAction == CharacterHana);
        
        if (currentDialogueData.position == PositionLeft)
        {
            DialogueText.transform.SetAsLastSibling();
        }
        else
        {
            DialogueText.transform.SetAsFirstSibling();
        }   

        DialogueText.DOText(currentDialogueData.dialogue, DOTextDelay)
            .OnComplete(() =>
            {
                typing = false;
                if (currentDialogueData.Action == ActionEnd)
                {
                    DialogueManager.Instance.EndDialogue();
                }
            }); // 완료시에만 애니메이션 활성화    
        
        // 캐릭터 이름, 이미지 로드
        NameText.text = currentDialogueData.characterName;
        string imagePath = $"{JsonFilePath}{currentDialogueData.imageSprite}";
        image.sprite = Resources.Load<Sprite>(imagePath);    
    }
    
    public void ClearUI()
    {
        DialogueText.text = string.Empty;
        NameText.text = string.Empty;
        gameObject.SetActive(false);
    }
}
