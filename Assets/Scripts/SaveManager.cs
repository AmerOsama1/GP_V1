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

    public  void LoadLevel()
    {
         SceneManager.LoadScene("4");
        // if (PlayerPrefs.HasKey("Level"))
        // {
        //     SceneManager.LoadScene(PlayerPrefs.GetString("Level"));
        // }
        // else
        // {
        //     Debug.LogWarning("No saved level found!");
        // }
    }
    public void NewGame()
    {
             PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
                    SceneManager.LoadScene("1");
                    

    }
}
