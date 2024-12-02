using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExpansion1 : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 targetPosition = new Vector3(2, 2, -5); // 확대할 구간의 위치
    public float targetSize = 2.0f; // 확대할 크기
    public float transitionDuration = 4.0f; // 카메라 확대에 걸리는 시간

    private Vector3 initialPosition;  
    private float initialSize;        
    private float elapsedTime = 0f;

    public GameObject Talk;

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
        Talk.SetActive(true);
    }
}
