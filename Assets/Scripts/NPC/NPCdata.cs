using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class DialogueData
{
    public int characterIndex;
    public string[] characterName;
    public string[] dialogue;
    public string[] position; //left  right
    public string imageSprite;
}

[Serializable]
public class DialogueInfo
{
    public DialogueData[] DialogueDatas;
}
