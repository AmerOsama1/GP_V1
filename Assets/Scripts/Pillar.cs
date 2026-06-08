using UnityEngine;

public class Pillar : MonoBehaviour
{
    [Header("Settings")]
    public float minY = 0f;
    public float maxY = 5f;
    public float changeSpeed = 1f;
    public float tolerance = 0.05f;

    [Header("References")]
    public Transform referencePillar;

    private bool increasing = false;
    private bool decreasing = false;
    private bool solved = false;
    public float matchTimer = 0f;

    void Update()
    {
        if (solved) return;

        Vector3 pos = transform.position;

        if (increasing)
            pos.y = Mathf.Min(pos.y + changeSpeed * Time.deltaTime, maxY);
        else if (decreasing)
            pos.y = Mathf.Max(pos.y - changeSpeed * Time.deltaTime, minY);

        transform.position = pos;

        if (IsAtTarget())
        {
            matchTimer += Time.deltaTime;

            if (matchTimer >= 3f)
            {
                solved = true;
                increasing = false;
                decreasing = false;
            }
        }
        else
        {
            matchTimer = 0f;
        }
    }

    public void StartIncrease() => increasing = true;
    public void StopIncrease() => increasing = false;
    public void StartDecrease() => decreasing = true;
    public void StopDecrease() => decreasing = false;

    public bool IsAtTarget()
    {
        if (referencePillar == null) return false;
        return Mathf.Abs(transform.position.y - referencePillar.position.y) < tolerance;
    }

    public bool IsSolved() => solved;
}