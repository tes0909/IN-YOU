using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingCredits : MonoBehaviour
{
    public RectTransform creditsText;
    public float scrollSpeed = 50f;   
    public float endYPosition = 1000f; 
    private Vector3 startPosition;
    public Image[] creditImages;
    public Vector3[] imagePositions;
    public float fadeDuration = 2f;
    public float imageDisplayTime = 5f;
    public float delayBeforeStart = 10f;
    public AudioSource bgmSource; 
    public AudioClip bgmClip;

    private void Start()
    {
        if (creditsText == null)
        {
            return;
        }
        startPosition = creditsText.localPosition;
        if (bgmSource != null && bgmClip != null)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = false; 
            bgmSource.Play();
        }

        StartCoroutine(DisplayImagesSequentially());
    }

    private void Update()
    {
        creditsText.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;

        float textHeight = creditsText.rect.height;
        float canvasHeight = creditsText.parent.GetComponent<RectTransform>().rect.height;
        if (creditsText.localPosition.y >= (textHeight * 10) + (canvasHeight / 2))
        {
            enabled = false;
        }
    }
    private IEnumerator DisplayImagesSequentially()
    {
        for (int i = 0; i < creditImages.Length; i++)
        {
            creditImages[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(delayBeforeStart);
        for (int i = 0; i < creditImages.Length; i++)
        {
            creditImages[i].gameObject.SetActive(true);
            creditImages[i].rectTransform.localPosition = imagePositions[i];
            yield return StartCoroutine(FadeImage(creditImages[i], 0f, 1f, fadeDuration));
            yield return new WaitForSeconds(imageDisplayTime);
            yield return StartCoroutine(FadeImage(creditImages[i], 1f, 0f, fadeDuration));

            creditImages[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(6f);
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    private IEnumerator FadeImage(Image image, float startAlpha, float endAlpha, float duration)
    {
        Color color = image.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        image.color = new Color(color.r, color.g, color.b, endAlpha); 
    }
}
