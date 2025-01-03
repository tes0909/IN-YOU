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
}

[Serializable]
public class DialogueInfo
{
    public DialogueData[] dialogueDatas;
}



