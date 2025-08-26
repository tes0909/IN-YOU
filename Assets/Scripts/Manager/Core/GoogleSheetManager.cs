using System.Collections.Generic;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

/// <summary>
/// 구글 시트에서 CSV 데이터를 불러와 Unity 내부에서 사용할 수 있도록 관리하는 클래스
/// </summary>
public class GoogleSheetManager : MonoBehaviour, IManager
{
    // 불러온 대화 데이터를 저장하는 리스트
    public List<DialogueData> dialogueList = new List<DialogueData>();
    
    [SerializeField] private DialogueSheet dialogueSheet;
    // 구글 스프레드시트 CSV export URL (공유 → 모든 사용자 보기 권한 필요)
    private string SheetUrl => dialogueSheet.sheetUrl;

    public bool IsInitialized { get; private set; }
    public static GoogleSheetManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init()
    {
        StartCoroutine(LoadSheet());
    }

    public void Clear()
    {
    }

    private IEnumerator LoadSheet()
    {
        UnityWebRequest www = UnityWebRequest.Get(SheetUrl); 
        yield return www.SendWebRequest(); 

        if (www.result != UnityWebRequest.Result.Success) 
        {
            Debug.LogError($"[GoogleSheetManager] Loading sheet failed: {www.error}");
        }
        else
        {
            string csvData = www.downloadHandler.text; 
            Debug.Log(csvData);
            ParseCSV(csvData);
            IsInitialized = true;
            Debug.Log($"[GoogleSheetManager] Loaded {dialogueList.Count} dialogues!");
        }
    }

    private void ParseCSV(string csv)
    {
        string[] rowData = csv.Split('\n'); 
        
        for (int i = 1; i < rowData.Length; i++)
        {
            if(string.IsNullOrWhiteSpace(rowData[i])) continue;

            string[] values = Regex.Split(rowData[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
            
            DialogueData dialogue = new DialogueData();
            dialogue.DIdx         = int.Parse(values[0].Trim('"'));
            dialogue.characterName = values[1].Trim('"');
            dialogue.dialogue      = values[2].Trim('"');
            dialogue.position      = values[3].Trim('"');
            dialogue.imageSprite   = values[4].Trim('"');
            dialogue.uiType        = values[5].Trim('"');
            dialogue.Action        = values[6].Trim('"');
            dialogue.specialAction = values[7].Trim('"');
            dialogue.PortalAction  = values[8].Trim('"');
            
            dialogueList.Add(dialogue);
        }
    }
}

