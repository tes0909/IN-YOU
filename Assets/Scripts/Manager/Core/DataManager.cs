using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public static DataManager instance;
   public DialogueInfo dialogueInfo;
   
   private const string DialogueJsonDataPath = "JsonData/dialogueDatas";
   private void Awake()
   {
       InitializeSingleton();
       LoadDialogueData();
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

   private void LoadDialogueData()
   {
       TextAsset dialogueJson = Resources.Load<TextAsset>(DialogueJsonDataPath);
       if (dialogueJson != null)
       {
           dialogueInfo = JsonUtility.FromJson<DialogueInfo>(dialogueJson.ToString());
           Debug.Log("JSON 파일 로드 성공");
       }
       else
       {
           Debug.LogError("JSON 파일 로드 실패");
       }
   }
}
