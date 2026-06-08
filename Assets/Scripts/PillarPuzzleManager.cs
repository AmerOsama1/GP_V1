using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PillarPuzzleManager : MonoBehaviour
{
    public Pillar[] pillars;
    public TextMeshProUGUI timerText;
    public UnityEvent onAllSolved;

    private bool solved = false;

    void Start()
    {
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (solved) return;

        bool anyAtTarget = false;

        foreach (Pillar p in pillars)
        {
            if (p.IsSolved()) continue;

            if (p.IsAtTarget())
            {
                anyAtTarget = true;
                timerText.gameObject.SetActive(true);
                timerText.text = (3f - p.matchTimer).ToString("F1");
                break;
            }
        }

        if (!anyAtTarget)
            timerText.gameObject.SetActive(false);

        foreach (Pillar p in pillars)
        {
            if (!p.IsSolved()) return;
        }

        solved = true;
        timerText.gameObject.SetActive(false);
        onAllSolved.Invoke();
    }
}