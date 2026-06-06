using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionsProgress : MonoBehaviour
{
    public static MissionsProgress instance;

    public Image progressFillImage;
    public int   totalMissions = 5;
    public float animDuration  = 0.6f; 

    int       _points = 0;
    Coroutine _anim;

    void Awake()
    {
        instance = this;
        if (progressFillImage != null)
            progressFillImage.fillAmount = 0f;
    }

    public void MissionCompleted()
    {
        if (_points >= totalMissions) return;

        _points++;
        Debug.Log($"Mission complete! Points: {_points}/{totalMissions}");

        AddProgress();

        if (_points >= totalMissions)
            Debug.Log("All missions done!");
    }

    public void AddProgress()
    {
        if (progressFillImage == null) return;

        float targetFill = totalMissions > 0
            ? Mathf.Clamp01((float)_points / totalMissions)
            : 0f;

        if (_anim != null) StopCoroutine(_anim);
        _anim = StartCoroutine(AnimateFill(targetFill));
    }

    IEnumerator AnimateFill(float target)
    {
        float start   = progressFillImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < animDuration)
        {
            elapsed += Time.deltaTime;
            float t  = Mathf.Clamp01(elapsed / animDuration);

            float ease = 1f - Mathf.Pow(1f - t, 3f);

            progressFillImage.fillAmount = Mathf.Lerp(start, target, ease);
            yield return null;
        }

        progressFillImage.fillAmount = target;
    }
}