using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : IManager
{
    public Player Player { get; private set; }
    public bool IsPaused = false;

    private MonsterSpawner monsterSpawner;

    public void Clear()
    {

    }

    public void Init()
    {
        GameStart();
    }

    public void GameStart()
    {
        // 실제로 게임을 시작하는 함수
        monsterSpawner = new MonsterSpawner();
        LevelContainer level = GameObject.FindFirstObjectByType<LevelContainer>();
        monsterSpawner.Initialize(level);
    }

    public void CreatePlayer()
    {
        Player player = GameObject.FindObjectOfType<Player>();

        if (player == null)
            player = Managers.Resource.Instantiate("Player/Player")?.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogWarning("Player 프리팹이 없습니다.");
            return;
        }

        player.gameObject.name = nameof(Player);
        //player.Condition.OnDead += GameOver;
        Player = player;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            OpenPauseUI();
        }
    }

    public void OpenPauseUI()
    {
        if (!IsPaused)
        {
            IsPaused = true;
            Managers.UI.ShowPopupUI<UIPausePopup>();
        }
        else
        {
            IsPaused = false;
            Managers.UI.ClosePopupUI<UIPausePopup>();
        }
    }
    
    public void GameOver()
    {
        // 실제로 게임이 종료되었을때 함수
        Managers.UI.ShowPopupUI<UIGameOverPopup>();
    }

    public void GameClear()
    {
        //// 게임 클리어시 함수
        //Managers.UI.ShowPopupUI<UIGameClearPopup>();
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
        //인풋 종료
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        //인풋 활성화
    }

    public void SaveGame()
    {
        //게임 저장 로직
    }

    public void LoadGame()
    {
        //게임 불러오기 로직
    }

    public void SetMonsterID(int monsterId)
    {
        monsterSpawner.monsterID = monsterId;
        monsterSpawner.StartMonsterSpawn();
    }
}
