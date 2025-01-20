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
    public int startNpcId, endNpcId;

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
            if (DialogueManager.Instance == null || DialogueManager.Instance.dialogueUI == null)
            {
                Debug.Log("DialogueManager or DialogueUI is not available.");
                return;
            }
            DialogueManager.Instance.EndDialogue();
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            if (DialogueManager.Instance == null || DialogueManager.Instance.dialogueUI == null)
            {
                Debug.Log("DialogueManager or DialogueUI is not ready.");
                return;
            }
            
            if (DialogueManager.Instance.dialogueIndex >= startNpcId && DialogueManager.Instance.dialogueIndex < endNpcId)
            {
                DialogueManager.Instance.StartDialogue(); 
            }
        }
    }
}
