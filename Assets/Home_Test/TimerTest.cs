using UnityEngine;
using UnityEngine.UI; 

public class TimerTest : MonoBehaviour
{
    public Text timerText; 
    private float timeRemaining = 60f;
    private bool isTimerRunning = false;

    void Start()
    {
        if (timerText != null)
        {
            timerText.text = FormatTime(timeRemaining);
        }

        isTimerRunning = true;
    }

    void Update()
    {
        if (isTimerRunning)
        {
     
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isTimerRunning = false;
            }

            timerText.text = FormatTime(timeRemaining);
        }
    }
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);  // Ка
        int seconds = Mathf.FloorToInt(time % 60);  // УЪ

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
