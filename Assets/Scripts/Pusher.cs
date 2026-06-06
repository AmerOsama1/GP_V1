using UnityEngine;

public class Pusher : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float horizontalSpeed = 3f;
    public float horizontalRange = 4f;

    [Header("Vertical Movement")]
    public float verticalSpeed = 2f;
    public float verticalRange = 2f;

    [Header("Push Settings")]
    public float pushForce = 10f;
    public string playerTag = "Player";

    private Vector3 _startPos;
    private Vector3 _currentVelocity;
    private Vector3 _lastPos;
    private Rigidbody _rb;

    void Start()
    {
        _startPos = transform.position;
        _lastPos = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float x = Mathf.Sin(Time.time * horizontalSpeed) * horizontalRange;
        float y = Mathf.Sin(Time.time * verticalSpeed)  * verticalRange;

        Vector3 newPos = new Vector3(
            _startPos.x + x,
            _startPos.y + y,
            _startPos.z
        );

        _currentVelocity = newPos - _lastPos;
        _lastPos = newPos;

        _rb.MovePosition(newPos);
    }

    void OnCollisionEnter(Collision col)
    {
        if (!col.gameObject.CompareTag(playerTag)) return;

        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        if (rb == null) return;

        Vector3 dir = -_currentVelocity.normalized;

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(dir * pushForce, ForceMode.Impulse);
    }
}