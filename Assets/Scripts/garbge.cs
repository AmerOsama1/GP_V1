using UnityEngine;
using System.Collections.Generic; 

public class garbge : MonoBehaviour
{
    public GameObject Laser;
    public List<GameObject> Garbges;

    void Start()
    {
    }

 void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Object"))
    {
        Garbges.Remove(other.gameObject);
        Destroy(other.gameObject);

        if (Garbges.Count == 0)
        {
            Laser.SetActive(false);
        }
    }
}
}