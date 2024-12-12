using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarNarration : MonoBehaviour
{
    public TextMeshProUGUI narrationText;
    public Button nextButton;
    private string[] narrationLines = {
        "Test",
        "long time no see",
        "america",
        "luck"
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
        Invoke("EnableButton", 3f);
    }
    private void EnableButton()
    {
        nextButton.interactable = true;
    }
}
