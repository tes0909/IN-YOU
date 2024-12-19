using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class FadeScript : MonoBehaviour
{
    private Light2D light2d;
    public float Ftime = 1f; // 페이드가 몇 초간 지속될지 정하는 값

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (light2d == null)
        {
            light2d = GetComponent<Light2D>();
        }
    }

    public void FadeIn()
    {
        Color color = light2d.color;

        DOTween.To(() => color, x => light2d.color = x, Color.white, Ftime);
    }

    public void Fade()
    {
        Color color = light2d.color;
        DOTween.To(() => color, x => light2d.color = x, Color.black, Ftime).OnComplete(() => FadeIn());
    }
}
