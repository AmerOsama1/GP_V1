using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridPuzzleManager : MonoBehaviour
{
    public GridTile[] tiles = new GridTile[16];

    public int[] correctShape;  

    [Header("References")]
    public GameObject player;
    public GameObject doorToOpen;
    public Transform playerStartPosition;

    private List<int> playerPath = new List<int>();
    private bool puzzleSolved = false;

void Start()
{
    for (int i = 0; i < tiles.Length; i++)
    {
        tiles[i].tileIndex = i;
    }
}



   
   public void OnPlayerStepOn(int tileIndex)
{
    if (puzzleSolved) return;

    if (IsCorrectTile(tileIndex))
    {
        if (!playerPath.Contains(tileIndex))
        {
            playerPath.Add(tileIndex);
            tiles[tileIndex].SetGreen();
        }

        if (playerPath.Count == correctShape.Length)
        {
            puzzleSolved = true;
            PuzzleSolved();
        }
    }
    else
    {
        StartCoroutine(WrongTileRoutine(tileIndex));
    }
}
   bool IsCorrectTile(int index)
{
    if (playerPath.Contains(index))
        return true;

    foreach (int correct in correctShape)
    {
        if (correct == index)
            return true;
    }

    return false;
}

 IEnumerator WrongTileRoutine(int tileIndex)
{
    tiles[tileIndex].SetRed();
    yield return new WaitForSeconds(0.5f);

    ResetPuzzle();

    Rigidbody rb = player.GetComponent<Rigidbody>();
    if (rb != null)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;                       
        yield return new WaitForFixedUpdate();
        player.transform.position = playerStartPosition.position;
        yield return new WaitForFixedUpdate();
        rb.isKinematic = false;                    
    }
}
    void ResetPuzzle()
    {
        playerPath.Clear();
        foreach (GridTile tile in tiles)
        {
            tile.Reset();
        }
    }

    void PuzzleSolved()
    {
        Debug.Log("Puzzle Solved!");
        if (doorToOpen != null)
            doorToOpen.SetActive(false); 
    }
}