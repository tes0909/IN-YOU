using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Choice : MonoBehaviour
{
    public Button eatButton;
    public Button doNotEatButton;
    public TextMeshProUGUI outputText;
    private SceneManagerEx sceneManagerEx;

    public void Start()
    {
        
        eatButton.onClick.AddListener(() => OnChoiceMade(true));
        doNotEatButton.onClick.AddListener(() => OnChoiceMade(false));
        eatButton.gameObject.SetActive(true);
        doNotEatButton.gameObject.SetActive(true);
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

        StartCoroutine(LoadNextScene());
    }
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);
        if (SceneManagerEx.Instance != null)
        {
            SceneManagerEx.Instance.LoadNextScene();
        }
    }
}
