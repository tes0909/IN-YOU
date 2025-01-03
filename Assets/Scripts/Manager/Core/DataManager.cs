using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   public DialogueInfo dialogueInfo;

   public static DataManager instance;
   private void Awake()
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

   private void Start()
   {
       var dialogueJson = Resources.Load("JsonData/dialogueDatas") as TextAsset;
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
