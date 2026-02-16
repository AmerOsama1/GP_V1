using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 1, 0);
    [SerializeField] private float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
