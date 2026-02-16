using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float distance = 5f;   // المسافة اللي هيطلعها
    public float speed = 2f;      // سرعة الحركة

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool goingUp = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * distance;
    }

    void Update()
    {
        if (goingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (transform.position == targetPos)
                goingUp = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

            if (transform.position == startPos)
                goingUp = true;
        }
    }
}
