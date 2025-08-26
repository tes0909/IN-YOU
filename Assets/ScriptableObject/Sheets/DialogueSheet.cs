using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSheet", menuName = "SO/DialogueSheet")]
public class DialogueSheet : ScriptableObject
{
    [Tooltip("구글 시트 CSV Export URL")]
    public string sheetUrl;
}
