using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public NPCData npcData; 
    private bool isPlayerNearby;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if(DialogueManager.Instance.DialogueActive())
            {
                DialogueManager.Instance.NextDialogue();
            }
            else
            {
                DialogueManager.Instance.StartDialogue(npcData);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>()!=null)
        {
            isPlayerNearby = true;
        }
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>()!=null)
        {
            isPlayerNearby = false;
            DialogueManager.Instance.EndDialogue();
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isPlayerNearby = true;
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         isPlayerNearby = false;
    //         DialogueManager.Instance.EndDialogue();
    //     }
    // }
}
