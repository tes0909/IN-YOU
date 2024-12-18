using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraExpansion3 : MonoBehaviour
{
    public Camera mainCamera;
    public float transitionDuration = 2.0f;
    public GameObject labNarration;
    public Image Scenecutimg;
    private Color Scenecutcolor;

    void Start()
    {
        StartCoroutine(TransitionToBright());
        
    }
    private IEnumerator TransitionToBright()
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            float t = elapsedTime / transitionDuration;
            float alphavalue = Mathf.Lerp(1, 0, t);
            Scenecutcolor.a = alphavalue;
            Scenecutimg.color = Scenecutcolor;
         
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (labNarration != null)
        {
            labNarration.gameObject.SetActive(true);
        }
    }
}
