using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LetterNarration : MonoBehaviour
{
    public TextMeshProUGUI narrationText; 
    public Button nextButton; 

    private string[] narrationLines = {
        "Dear",
        "Hi",
        "Missing you",
        "Come Here"
    };

    private int currentIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        narrationText.text = narrationLines[currentIndex];
    }

    public void OnNextButtonClick()
    {
        nextButton.interactable = false; // 버튼 클릭 비활성화
        currentIndex++;

        // 텍스트 변경
        if (currentIndex < narrationLines.Length)
        {
            narrationText.text = narrationLines[currentIndex];
            Debug.Log(currentIndex);
        }
        else
        {
            nextButton.interactable = false;
            Debug.Log("모든 문장이 출력되었습니다.");
        }

        // 3초 후에 버튼 활성화
        Invoke("EnableButton", 3f);
    }

    private void EnableButton()
    {
        nextButton.interactable = true; // 버튼 활성화
    }
}
