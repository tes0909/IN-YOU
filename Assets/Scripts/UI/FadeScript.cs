using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image panel;
    private float time = 0f; // 0~1까지 deltatime 계속 더하는 지속시간
    private float Ftime = 1f; // 페이드가 몇 초간 지속될지 정하는 값

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = panel.color;
        while (alpha.a < 1.0f)
        {
            time += Time.deltaTime / Ftime;
            alpha.a = Mathf.Lerp(0, 1, time);
            panel.color = alpha;
            yield return null;
        }
        time = 0f;
        yield return new WaitForSeconds(1f);
        
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / Ftime;
            alpha.a = Mathf.Lerp(1, 0, time);
            panel.color = alpha;
            yield return null;
        }
        panel.gameObject.SetActive(false);
        yield return null;
    }
}
