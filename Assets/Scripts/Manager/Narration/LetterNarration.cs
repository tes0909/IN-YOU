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
        nextButton.interactable = false; 
        currentIndex++;
        if (currentIndex < narrationLines.Length)
        {
            narrationText.text = narrationLines[currentIndex];
            Debug.Log(currentIndex);
        }
        else
        {
            nextButton.interactable = false;
        }
        Invoke("EnableButton", 2f);
    }
    private void EnableButton()
    {
        nextButton.interactable = true; 
    }
}
