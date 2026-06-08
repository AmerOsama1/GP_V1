using UnityEngine;

public class PillarTrigger : MonoBehaviour
{
    public Pillar pillar;
    public bool isIncrease; 

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isIncrease)
            pillar.StartIncrease();
        else
            pillar.StartDecrease();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isIncrease)
            pillar.StopIncrease();
        else
            pillar.StopDecrease();
    }
}