using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel  : MonoBehaviour
{
    public string sceneToLoad;
    public int levelToSave;
    public string nameOfLevel;
    public Transform[] lvls;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int savedLevel = PlayerPrefs.GetInt(nameOfLevel, 0);

            if (levelToSave == savedLevel)
            {
                int nextLevel = levelToSave >= lvls.Length - 1 ? lvls.Length - 1 : levelToSave + 1;
                PlayerPrefs.SetInt(nameOfLevel, nextLevel);
                PlayerPrefs.Save();

                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}