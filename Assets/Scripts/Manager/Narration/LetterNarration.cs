using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class LetterNarration : MonoBehaviour
{
    public TextMeshProUGUI narrationText; 
    public Button nextButton; 
    private string[] narrationLines = {
        "나의 유일한 가족이자 친구, 담에게",
       "미안해 담아",
       "죽기 전에야 멀리서 용기를 낸 나를 용서하길 바랄게",
       "이 편지를 읽게 될 즈음이라면...",
       "아마 나는 죽었을거야",
       "하루가 채 지나진 않았겠지",
       "너에게 부탁할 것이 하나 있어",
       "우리의 약속을 잊지 않았다면..",
       "편지가 발송된 곳으로 찾아와 나의 유서를 읽어주지 않겠어?",
       "갑작스레 이런 부탁을 해서 미안해",
       "너 밖에 없더라구",
       "-경-"


    };
    private int currentIndex = 0;
    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        narrationText.text = "";
    }

    public void OnNextButtonClick()
    {
        nextButton.interactable = false; 
       
        if (currentIndex < narrationLines.Length)
        {
            DisplayTextWithTween(narrationLines[currentIndex]);
            currentIndex++;
        }
        else
        {
            nextButton.interactable = false;
        }
        Invoke("EnableButton", 2f);
    }
    private void DisplayTextWithTween(string line)
    {
        narrationText.text = "";
        DOTween.Kill(narrationText);
        narrationText.DOText(line, 1f) 
        .SetEase(Ease.Linear) 
        .OnStart(() => narrationText.maxVisibleCharacters = 0)
        .OnUpdate(() =>
        {
            int visibleCharacters = Mathf.FloorToInt(narrationText.textInfo.characterCount * 1f);
            narrationText.maxVisibleCharacters = visibleCharacters;
        });
    }
    private void EnableButton()
    {
        nextButton.interactable = true; 
    }
}
