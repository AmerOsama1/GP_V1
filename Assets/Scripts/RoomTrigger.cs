using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GridPuzzleManager roomManager;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        other.GetComponent<PlayerGridDetector>().currentManager = roomManager;
    }
}