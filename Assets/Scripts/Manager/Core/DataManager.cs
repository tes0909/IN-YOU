using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager instance;
   public DialogueInfo dialogueInfo;
   
   private void Awake()
   {
       InitializeSingleton();
       StartCoroutine(LoadDialogueData());
   }
   
   private void InitializeSingleton()
   {
       if (instance == null)
       {
           instance = this;
           DontDestroyOnLoad(gameObject);
       }
       else
       {
           Destroy(gameObject);
       }
   }

   private IEnumerator LoadDialogueData()
   {
       while (GoogleSheetManager.Instance == null || !GoogleSheetManager.Instance.IsInitialized)
       {
           yield return null;
       }

       // CSV에서 불러온 데이터를 DialogueInfo로 변환
       dialogueInfo = new DialogueInfo
       {
           dialogueDatas = GoogleSheetManager.Instance.dialogueList.ToArray()
       };

       Debug.Log($"[DataManager] DialogueInfo initialized with {dialogueInfo.dialogueDatas.Length} entries!");
   }
}
