using UnityEngine;
using System.Collections;

public class StandingCheck : MonoBehaviour
{
    [Header("Settings")]
    public bool isValid = true;

    [Header("Visuals")]
    public Color validColor = Color.green;
    private Renderer objectRenderer;
    private bool puzzleStarted = false;

    private  float revealTimer = 5f;
    private  bool timerDone = false;
    private  bool coroutineStarted = false;
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        objectRenderer.material.color = isValid ? Color.green : Color.red;

        if (!coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(RevealTimerCoroutine());
        }
    }

    IEnumerator RevealTimerCoroutine()
    {
        yield return new WaitForSeconds(revealTimer);

        timerDone = true;
        NotifyAllObjects();
    }

    void NotifyAllObjects()
    {
        StandingCheck[] allObjects = FindObjectsByType<StandingCheck>(FindObjectsSortMode.None);
        foreach (StandingCheck obj in allObjects)
        {
            obj.ResetToWhite();
        }
    }

    void ResetToWhite()
    {
        objectRenderer.material.color = Color.white;
        puzzleStarted = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!puzzleStarted) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        if (isValid)
            objectRenderer.material.color = validColor;
        else
            gameObject.SetActive(false);
    }
}