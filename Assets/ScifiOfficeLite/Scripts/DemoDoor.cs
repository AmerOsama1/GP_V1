using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScifiOffice {
    public class DemoDoor : MonoBehaviour {
      public GameObject MainDoor;
      AudioSource sc;
      [SerializeField] AudioClip clip;
      [SerializeField] bool _MainLetter;
        private void Start() {
             sc=GetComponent<AudioSource>();
        }
private void OnTriggerEnter(Collider other)
{
    if(other.gameObject.name == "Player")
    {
        if(_MainLetter)
        {
            MainDoor.SetActive(false);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        Destroy(gameObject);
    }
}

}}