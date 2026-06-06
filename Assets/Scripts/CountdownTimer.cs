using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float timeInSeconds = 30f;

    [Header("References")]
    public GameObject[] objectsToShow;  
    public TextMeshProUGUI timerText;

    private float currentTime;
    private bool timerRunning = false;

    void Start()
    {
        currentTime = timeInSeconds;

        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        StartTimer();
    }

    void Update()
    {
        if (!timerRunning) return;

        currentTime -= Time.deltaTime;

        if (timerText != null)
            timerText.text = Mathf.CeilToInt(currentTime).ToString();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timerRunning = false;
            OnTimerEnd();
        }
    }

    void StartTimer()
    {
        timerRunning = true;
    }

    void OnTimerEnd()
    {
        Debug.Log("Timer finished! Showing objects...");

        foreach (GameObject obj in objectsToShow)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}