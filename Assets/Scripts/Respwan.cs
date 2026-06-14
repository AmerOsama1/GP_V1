using UnityEngine;

public class Respwan : MonoBehaviour
{
    public Transform ResPosition;
     AudioSource audioSource;
    public AudioClip respawnSound;


void Start(){
  audioSource=GetComponent<AudioSource>();
}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = ResPosition.position;
            audioSource.PlayOneShot(respawnSound);
        }
    }
}