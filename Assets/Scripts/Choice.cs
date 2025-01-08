using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choice : MonoBehaviour
{
    public Button eatButton;
    public Button doNotEatButton;
    public TextMeshProUGUI outputText;

    public void Start()
    {
        
        eatButton.onClick.AddListener(() => OnChoiceMade(true));
        doNotEatButton.onClick.AddListener(() => OnChoiceMade(false));

        eatButton.gameObject.SetActive(false);
        doNotEatButton.gameObject.SetActive(false);
        outputText.text = ""; 
    }

    public void ActivateChoices()
    {
        eatButton.gameObject.SetActive(true);
        doNotEatButton.gameObject.SetActive(true);
    }

    public void OnChoiceMade(bool isEating)
    {
        if (isEating)
        {
            outputText.text = "A";
        }
        else
        {
            outputText.text = "B";
        }

        eatButton.gameObject.SetActive(false);
        doNotEatButton.gameObject.SetActive(false);
    }
}
