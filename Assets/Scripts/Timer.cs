using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 300f;
    public TextMeshProUGUI timerText;

    public AudioSource audioSource;
    public AudioClip warningClip;

    private bool isRunning = true;
    private bool playedWarning = false;

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

                if (timeRemaining <= 60f)
                {
                    if (!playedWarning)
                    {
                        audioSource.PlayOneShot(warningClip);
                        playedWarning = true;
                    }

                    timerText.color = Color.red;
                }

                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
                UpdateTimerDisplay(timeRemaining);
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}