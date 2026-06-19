using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float totalTime = 60f;

    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}