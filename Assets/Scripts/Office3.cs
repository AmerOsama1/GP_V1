using UnityEngine;

public class Office3 : MonoBehaviour
{
       public GameObject ELV;
 void OnTriggerEnter(Collider other)
 {
        if (other.CompareTag("Player"))
        {
            ELV.SetActive(true);
        }
 }
}
