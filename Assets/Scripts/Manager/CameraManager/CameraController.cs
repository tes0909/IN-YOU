using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [HideInInspector]
    public Transform player;

    private Vector3 boundary1;
    private Vector3 boundary2;
    private float halfHeight;
    private float halfWidth;

    // 타일맵 경계 설정
    public void SetTilemapBounds(Tilemap tilemap)
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        tilemap.CompressBounds();

        boundary1 = tilemap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        boundary2 = tilemap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    // LateUpdate에서 카메라 이동 처리
    void LateUpdate()
    {
        if (player != null)
        {
            // 플레이어를 따라 카메라 위치 업데이트
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);

            // 카메라가 경계를 벗어나지 않도록 제한
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, boundary1.x, boundary2.x),
                Mathf.Clamp(transform.position.y, boundary1.y, boundary2.y),
                transform.position.z
            );
        }
    }
}
