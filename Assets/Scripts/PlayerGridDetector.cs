using UnityEngine;

public class PlayerGridDetector : MonoBehaviour
{
    public GridPuzzleManager currentManager;

    void OnCollisionEnter(Collision collision)
    {
        if (currentManager == null) return;
        
        GridTile tile = collision.gameObject.GetComponent<GridTile>();
        if (tile != null)
        {
            currentManager.OnPlayerStepOn(tile.tileIndex);
        }
    }
}