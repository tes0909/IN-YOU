using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NPC : MonoBehaviour
{
    //public NPCData npcData; 
    private bool isPlayerNearby;
    private SortingGroup sortingGroup;
    private readonly int sortingOrderModifier = -10;

    private void Start()
    {
        sortingGroup = GetComponent<SortingGroup>();
        if (sortingGroup != null)
        {
            sortingGroup.sortingOrder = (int)(transform.position.y * sortingOrderModifier);
        }
    }

    private void Update()
    {
        // if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        // {
        //     if(DialogueManager.Instance.DialogueActive())
        //     {
        //         DialogueManager.Instance.NextDialogue();
        //     }
        //     else
        //     {
        //         DialogueManager.Instance.StartDialogue(npcData);
        //     }
        // }
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
            // DialogueManager.Instance.EndDialogue();
        }
    }
}
