using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class DialogueData
{
    public int DIdx;
    public string characterName;
    public string dialogue;
    public string position;
    public string imageSprite;
    public string uiType;
    public string Action;
}

[Serializable]
public class DialogueInfo
{
    public DialogueData[] dialogueDatas;
}



