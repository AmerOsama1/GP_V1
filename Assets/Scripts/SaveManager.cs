using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    static string currentSceneLevel;

    void Start()
    {
        currentSceneLevel = SceneManager.GetActiveScene().name;
    }

    public static void SaveLevel()
    {
        PlayerPrefs.SetString("Level", currentSceneLevel);
        PlayerPrefs.Save();
    }

    public static void LoadLevel()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        }
        else
        {
            Debug.LogWarning("No saved level found!");
        }
    }
    public void NewGame()
    {
                    SceneManager.LoadScene("1");

    }
}
