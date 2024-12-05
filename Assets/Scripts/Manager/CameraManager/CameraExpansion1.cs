using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraExpansion1 : MonoBehaviour
{
    public Camera mainCamera;

    public Vector3 targetPosition = new Vector3(2, 2, -5); 
    public float targetSize = 2.0f; 
    public float transitionDuration = 4.0f; 

    private Vector3 initialPosition;  
    private float initialSize;        
    private float elapsedTime = 0f;

    public GameObject Talk;

    void Start()
    {

        initialPosition = new Vector3(0f, 0f, -5f);
        initialSize = mainCamera.orthographicSize;

        
        StartCoroutine(DoZoomIn());
    }

    private IEnumerator DoZoomIn()
    {
        float timeElapsed = 0f;
        
        while (timeElapsed < transitionDuration)
        {
            float t = timeElapsed / transitionDuration; 
            mainCamera.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
            mainCamera.orthographicSize = Mathf.Lerp(initialSize, targetSize, t);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        
        mainCamera.transform.position = targetPosition;
        mainCamera.orthographicSize = targetSize;
        yield return new WaitForSeconds(1f);
        Talk.SetActive(true);
    }
}
