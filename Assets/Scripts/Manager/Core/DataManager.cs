using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   private DialogueInfo dialogueInfo;

   private void Start()
   {
       var dialogueJson = Resources.Load<TextAsset>("JsonData/DialougueDatas");
       dialogueInfo = JsonUtility.FromJson<DialogueInfo>(dialogueJson.ToString());
   }
}
