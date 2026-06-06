using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float horizontalSpeed = 3f;
    public float horizontalRange = 4f;

    [Header("Vertical Movement")]
    public float verticalSpeed = 2f;
    public float verticalRange = 2f;

    private Vector3 _startPos;

    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange;
        float y = Mathf.Sin(Time.time * verticalSpeed) * verticalRange;

        transform.position = new Vector3(
            _startPos.x + x,
            _startPos.y + y,
            _startPos.z
        );
    }
}