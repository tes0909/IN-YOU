using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExpansion2 : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 targetPosition = new Vector3(1, -3, -5);
    public float targetSize = 2.0f; 
    public float transitionDuration = 4.0f; 

    private Vector3 initialPosition;
    private float initialSize;
    private float elapsedTime = 0f;

    public GameObject News;

    void Start()
    {

        initialPosition = new Vector3(0f, 0f, -5f);
        initialSize = mainCamera.orthographicSize;

        // 확대 효과 시작
        StartCoroutine(DoZoomIn());
    }

    private IEnumerator DoZoomIn()
    {
        float timeElapsed = 0f;
        // 카메라 확대 효과 시작
        while (timeElapsed < transitionDuration)
        {
            float t = timeElapsed / transitionDuration;
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, t);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // 목표 위치와 크기에 도달한 후 완료
        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetSize;

        yield return new WaitForSeconds(1f);
        News.SetActive(true);
    }
}

