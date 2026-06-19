using UnityEngine;

public class Room4 : MonoBehaviour
{
   public CheckCRoom cr;
bool ishecked;
   [SerializeField]  string boxColor ;
  void OnTriggerEnter(Collider other)
  {
        if (other.CompareTag("Object")||other.gameObject.name ==(boxColor))
        {
            other.transform.rotation=this.transform.rotation;
            if(!ishecked){
            for (int i = 0; i < cr.isdone.Length; i++)
            {
                if (!cr.isdone[i])
                {
                    ishecked=true;
                    cr.isdone[i]=true;
                    break;
                }
            }}
        }
  }
}
