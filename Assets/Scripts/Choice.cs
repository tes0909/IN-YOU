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
            outputText.text = "네가 원한 건 먹는 거겠지. 그래, 먹어줄게";
        }
        else
        {
            outputText.text = "네가 바란거지만, 난 못해. 안먹겠어";
        }
        eatButton.gameObject.SetActive(false);
        doNotEatButton.gameObject.SetActive(false);

        StartCoroutine(LoadNextScene());
    }
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);

        UnityEngine.SceneManagement.SceneManager.LoadScene("12_EndingCredits");

    }
}
