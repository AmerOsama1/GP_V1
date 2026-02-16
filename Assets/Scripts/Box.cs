using UnityEngine;

public class Box : MonoBehaviour
{
    AudioSource source;
    Rigidbody rb;
    bool isGrounded;

     SoundManager sm;

    [Header("Movement Settings")]
    [SerializeField] float moveThreshold = 0.05f;

    void Start()
    {
        sm = SoundManager.Instance;
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool isMoving =
            rb.linearVelocity.magnitude > moveThreshold ||
            rb.angularVelocity.magnitude > moveThreshold;

        if (isMoving && isGrounded)
        {
            if (!source.isPlaying)
                sm.PlaySoundclip(sm.push, true, source);
        }
        else
        {
            if (source.isPlaying)
                sm.PlaySoundclip(sm.push, false, source);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
