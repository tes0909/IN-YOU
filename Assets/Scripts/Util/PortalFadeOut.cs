using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalFadeOut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"충돌 : {other.name}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어는 포탈에 들어갔습니다.");
            Managers.Scene.LoadLaterScene();
        }
    }
}
