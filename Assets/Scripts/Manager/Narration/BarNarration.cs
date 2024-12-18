using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarNarration : MonoBehaviour
{
    public TextMeshProUGUI narrationText;
    public Button nextButton;
    public Image displayImage;
    public Sprite[] narrationImages;

    public GameObject gameObject1;
    public GameObject gameObject2;
    private int toggleCount = 0;
    private bool isObject1Active = true;

    private string[] narrationLines = {
        "오랜만이야, 잘 지냈어?",
        "그럼~ 잘 지냈지.",
        "다행이네. 그거 알아? 우리가 거길 나온지 벌써 10년이 흘렀더라",
        "벌써? 시간 참 빠르네.",            
        "그러게 말이야",
        "시시콜콜한 얘기나 나누려고 부르진 않았을 것 같고, 또 무슨 자랑거리가 있어 부르셨나 그래",
        "하여튼 눈치가 빨라요. 나 결혼할 것 같은 사람이 생겼어",
        "너를 구제해줄 사람이 생겼단 말이야? 어디 봐바",
        "구제는 무슨...자, 이 사람이야.",
        "이쁘시네, 이름이?",
        "하나.", 
        "하니?..꽃? 일본 사람인가?",
        "역시..일본어랑 친숙한 너답다. 영상을 많이 보더라니",
        "...그거랑 상관없거든.",
        "다음주에 미국으로 여행을 가려고 해. 다녀와서 소개시켜줄게.",
        "다음주? 보자..크리스마스 이브구만? 부럽다~ 잘 다녀와",
        "뭐 갖고싶은 건 없어? 가다가 보이면 하나쯤 사줄수도 있는데",
        "에이, 됐어. 둘이 잘 놀다와.",
        "나 세번은 말 안하는거 알지? 마지막으로 물어볼게. 정말 없어?",
        "크흠..그렇게까지 말한다면야..승리의 여신 이라는 게임이 있는데 거기서 나오는 한정판 련이가 뉴욕에....",

    };
    private int currentIndex = 0;
    void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
        UpdateNarration();
        ActivateGameObject1();
    }
    public void OnNextButtonClick()
    {
        nextButton.interactable = false;
        currentIndex++;

        if (currentIndex < narrationLines.Length)
        {
            UpdateNarration();
        }
        else
        {
            nextButton.interactable = false;
        }
        Invoke("EnableButton", 1f);

        if (toggleCount >= 19)
        {
            return; 
        }

        if (isObject1Active)
        {
            ActivateGameObject2(); 
        }
        else
        {
            ActivateGameObject1();
        }

        isObject1Active = !isObject1Active; 
        toggleCount++;
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

    private void UpdateNarration()
    {
        narrationText.text = narrationLines[currentIndex];
        if (currentIndex == 8)
        {
            if (currentIndex < narrationImages.Length && narrationImages[currentIndex] != null)
            {
                displayImage.sprite = narrationImages[currentIndex];
                displayImage.gameObject.SetActive(true); 
            }
            else
            {
                displayImage.gameObject.SetActive(false);
            }
        }
        else
        {
            if (displayImage.gameObject.activeSelf)
            {
                displayImage.gameObject.SetActive(false);
            }
        }
    }
    private void EnableButton()
    {
        nextButton.interactable = true;
    }
}
