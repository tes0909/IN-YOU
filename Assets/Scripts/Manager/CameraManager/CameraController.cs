using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform player; 
    public Tilemap tilemap;  

    private Vector3 boundary1; // 타일맵 경계 최소값
    private Vector3 boundary2; // 타일맵 경계 최대값
    private float halfHeight;  // 카메라 높이의 절반
    private float halfWidth;   // 카메라 너비의 절반

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera가 설정되지 않았습니다!");
            return;
        }
    }

    private void Start()
    {
        InitializeCamera();
    }

    public void InitializeCamera()
    {
        SetCameraAspect(); 
        if (tilemap != null)
        {
            SetTilemapBounds();
        }
        else
        {
            Debug.LogWarning("Tilemap이 연결되지 않았습니다!");
        }
    }

    private void SetCameraAspect()
    {
        float targetAspect = 16.0f / 9.0f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (mainCamera == null) return;

        if (scaleHeight < 1.0f)
        {
            Rect rect = mainCamera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            mainCamera.rect = rect;
        }
        else
        {
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = mainCamera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            mainCamera.rect = rect;
        }
    }

    private void SetTilemapBounds()
    {
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * mainCamera.aspect;

        tilemap.CompressBounds();

        boundary1 = tilemap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        boundary2 = tilemap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // 플레이어를 따라 카메라 위치 업데이트
            Vector3 newPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            // 카메라가 경계를 벗어나지 않도록 제한
            newPosition.x = Mathf.Clamp(newPosition.x, boundary1.x, boundary2.x);
            newPosition.y = Mathf.Clamp(newPosition.y, boundary1.y, boundary2.y);

            transform.position = newPosition;
        }
    }

}
