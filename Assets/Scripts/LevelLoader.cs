using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject player;
    public string nameOfLevel;

    void Awake()
    {
        int savedLevel = PlayerPrefs.GetInt(nameOfLevel, -1);
        Debug.Log(savedLevel);

        if (savedLevel < 0 || savedLevel >= spawnPoints.Length)
        {
            return;
        }

        if (player == null)
        {
            return;
        }

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.MovePosition(spawnPoints[savedLevel].position);
            rb.MoveRotation(spawnPoints[savedLevel].rotation);
        }
     
    }

    public void GOTOMAiN()
    {
        SceneManager.LoadScene("4");
    }
}