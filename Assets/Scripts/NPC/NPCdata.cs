using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCData", menuName = "Dialogue/NPC Data")]
public class NPCData : ScriptableObject
{
    public string npcName;           
    public string[] dialogueLines;  
}
