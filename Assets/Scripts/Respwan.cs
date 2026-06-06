using UnityEngine;

public class Respwan : MonoBehaviour
{
  public Transform ResPosition;


  void OnTriggerEnter(Collider other)
  {
      if(other.CompareTag("Player")){
        other.transform.position=ResPosition.position;
      }
  }
}
