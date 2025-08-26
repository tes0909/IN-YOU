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
            outputText.text = "�װ� ���� �� �Դ� �Ű���. �׷�, �Ծ��ٰ�";
        }
        else
        {
            outputText.text = "�װ� �ٶ�������, �� ����. �ȸ԰ھ�";
        }
        eatButton.gameObject.SetActive(false);
        doNotEatButton.gameObject.SetActive(false);

        StartCoroutine(LoadNextScene());
    }
    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("12_EndingCredits");
    }
}
