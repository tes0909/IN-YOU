using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IManager
{
    //public Player Player { get; private set; }
    //private MonsterSpawner monsterSpawner;

    public void Clear()
    {

    }

    public void Init()
    {

    }

    public void GameStart()
    {
        //// 실제로 게임을 시작하는 함수
        //monsterSpawner = new MonsterSpawner();
        //Player.Input.InputEnable();
    }

    public void CreatePlayer(int jobid)
    {
        //Player player = GameObject.FindObjectOfType<Player>();

        //if (player == null)
        //    player = Managers.Resource.Instantiate("Player")?.GetComponent<Player>();

        //if (player == null)
        //{
        //    Debug.LogWarning("Player 프리팹이 없습니다.");
        //    return;
        //}

        //player.gameObject.name = nameof(Player);
        //player.Condition.OnDead += GameOver;
        //Player = player;
    }

    public void GameOver()
    {
        //// 실제로 게임이 종료되었을때 함수
        //Managers.UI.ShowPopupUI<UIGameOverPopup>();
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
}
