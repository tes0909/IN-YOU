using UnityEngine;
using UnityEngine.InputSystem;

public class UIPausePopup : UIPopupBase
{
    public GameObject EscUI;

    private bool isPaused = false; // 일시정지 상태인지

    //private void Start()
    //{
    //    if (EscUI != null)
    //    {
    //        EscUI.SetActive(false);
    //    }
    //}

    //private void Update()
    //{
    //    if (Keyboard.current.escapeKey.wasPressedThisFrame)
    //    {
    //        TogglePauseMenu();
    //    }
    //}

    public void TogglePauseMenu() // UI 활성, 비활성
    {
        isPaused = !isPaused;

        if (EscUI != null)
        {
            EscUI.SetActive(isPaused);
        }

        Time.timeScale = isPaused ? 0f : 1f; // 시간 일시정지, 복구
    }

    // 추가로 저장, 불러오기 , 나가기 기능 구현 할 곳 
    // 각자 함수들을 버튼에 할당 해주기, EventSystem 확인 할 것
}
