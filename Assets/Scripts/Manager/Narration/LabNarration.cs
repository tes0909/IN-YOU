using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LabNarration : MonoBehaviour
{
    public TextMeshProUGUI narrationText;
    public Button nextButton;
    public GameObject gameObject1;
    public GameObject gameObject2;
    private int toggleCount = 0;
    private bool isObject1Active = true;

    private string[] narrationLines = {
        "반갑습니다. 성함이 '담'이 맞으실까요?",
        "네, 제가 맞습니다.",
        "인천공항을 출발해 미국 뉴욕으로 가던 ㅁㅁ항공 보잉 530이 태평양 한가운데서 폭발을 일으켰습니다.",
        "현재 미군은 해군와 군용기를 급파해 추적에 나섰습니다",
        "12월 24일 오후 8시에 출발한 이 비행기에는 한국인 27명, 일본인 3명, 미국인 17명이 탑승하고 있었으며,",
        "탑승자 명단은 방송 이후 항공사와 저희 KTN 홈페이지에서 다시 확인할 수 있습니다.",
        "한국인 탑승자 명단에는 '박수연,김유민,이건호...담...",

    };
    private int currentIndex = 0;

    void Start()
    {
        ActivateGameObject1();
        nextButton.onClick.AddListener(OnNextButtonClick);
        narrationText.text = narrationLines[currentIndex];
    }
    public void OnNextButtonClick()
    {
        currentIndex++;
        nextButton.interactable = false;

        if (currentIndex < narrationLines.Length)
        {
            narrationText.text = narrationLines[currentIndex];
            Debug.Log(currentIndex);
        }
        else
        {
            nextButton.interactable = false;
        }
        if (isObject1Active)
        {
            ActivateGameObject2();  // gameObject1을 비활성화하고 gameObject2를 활성화
        }
        else
        {
            ActivateGameObject1();  // gameObject2를 비활성화하고 gameObject1을 활성화
        }
        isObject1Active = !isObject1Active;
        Invoke("EnableButton", 1f);
    }
    private void ActivateGameObject1()
    {
        gameObject1.SetActive(true);
        gameObject2.SetActive(false);
    }

    private void ActivateGameObject2()
    {
        gameObject1.SetActive(false);
        gameObject2.SetActive(true);
    }
    private void EnableButton()
    {
        nextButton.interactable = true;
    }
}
