using UnityEngine;

public class disapper : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("ss", 1);
    }

    void OnDisable()
    {
        CancelInvoke("ss");
    }

    void ss()
    {
        this.gameObject.SetActive(false);
    }
}