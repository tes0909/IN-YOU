using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    public DialogueInfo currentDialogueInfo;
    public DialogueData dialogueData;
    private bool isPlayerNearby;
    private SortingGroup sortingGroup;
    private readonly int sortingOrderModifier = -10;
    public int startNpcId;
    private bool waitEndDialogue; // 대화종료대기

    private void Start()
    {
        sortingGroup = GetComponent<SortingGroup>();
        if (sortingGroup != null)
        {
            sortingGroup.sortingOrder = (int)(transform.position.y * sortingOrderModifier);
        }
        currentDialogueInfo = DataManager.instance.dialogueInfo;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player) 
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            isPlayerNearby = false;
            DialogueManager.Instance.EndDialogue();
            waitEndDialogue = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (DialogueManager.Instance.dialogueIndex >= startNpcId && !DialogueManager.Instance.dialogueUI.typing)
            {
                if (waitEndDialogue) 
                { 
                    DialogueManager.Instance.EndDialogue(); 
                    waitEndDialogue = false; 
                    this.enabled = false; 
                    return;
                }
                
                dialogueData = currentDialogueInfo.dialogueDatas[DialogueManager.Instance.dialogueIndex];

                switch (dialogueData.Action) 
                { 
                    case "Start": 
                    case "Continue": 
                        DialogueManager.Instance.StartDialogue(); 
                        break; 

                    case "End": 
                        DialogueManager.Instance.StartDialogue(); 
                        waitEndDialogue = true; // 종료 대기 상태 
                        break; 
                    
                    default:
                        Debug.Log("액션이 없습니다");
                        break;
                } 
                Debug.Log(DialogueManager.Instance.dialogueIndex); 
            }
        }
    }
}
