using UnityEngine;

public class AskHelp : MonoBehaviour
{
    [SerializeField] GameObject Help;
   void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player"))
        {
            Help.SetActive(true);
        }
   }

   void OnTriggerExit(Collider other)
   {
        if (other.CompareTag("Player"))
        {
              Help.SetActive(false);
        }
   }
}
