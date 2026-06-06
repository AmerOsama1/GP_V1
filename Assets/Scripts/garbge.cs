using UnityEngine;
using System.Collections.Generic; 

public class garbge : MonoBehaviour
{
    public GameObject Laser;
    public List<GameObject> Garbges;

    void Start()
    {
        Garbges = new List<GameObject>(); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            Destroy(other.gameObject); 
            Garbges.Remove(gameObject); 

            if (Garbges.Count == 0)
            {
                Laser.SetActive(false);
            }

    }
}}