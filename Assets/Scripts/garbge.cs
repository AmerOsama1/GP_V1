using UnityEngine;
using System.Collections.Generic; 

public class garbge : MonoBehaviour
{
    public GameObject Laser;
    public List<GameObject> Garbges;
    public AudioSource audioSource;
    public AudioClip destroySound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Garbges.Remove(other.gameObject);
            audioSource.PlayOneShot(destroySound);
            Destroy(other.gameObject);

            if (Garbges.Count == 0)
            {
                Laser.SetActive(false);
            }
        }
    }
}