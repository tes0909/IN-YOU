using System;
using Unity.VisualScripting;
using UnityEngine;

public class PortalForDemo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"충돌 : {other.name}");
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            Debug.Log("플레이어는 포탈에 들어갔습니다.");
            Managers.Scene.LoadNextScene();
        }
    }
}
