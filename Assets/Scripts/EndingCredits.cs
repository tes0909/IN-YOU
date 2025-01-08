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
    public float imageDisplayTime = 2f;
    public float delayBeforeStart = 3f;

    private void Start()
    {
        if (creditsText == null)
        {
            return;
        }
        startPosition = creditsText.localPosition;
        StartCoroutine(DisplayImagesSequentially());
    }

    private void Update()
    {
        creditsText.localPosition += Vector3.up * scrollSpeed * Time.deltaTime;
        float textHeight = creditsText.rect.height;
        float canvasHeight = creditsText.parent.GetComponent<RectTransform>().rect.height;
        if (creditsText.localPosition.y >= textHeight + canvasHeight / 2)
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
            yield return new WaitForSeconds(imageDisplayTime);
            creditImages[i].gameObject.SetActive(false);
        }
    }
}
