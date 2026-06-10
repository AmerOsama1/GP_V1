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
      PlayerPrefs.SetInt(nameOfLevel, levelToSave);
             PlayerPrefs.Save();

            SceneManager.LoadScene(sceneToLoad);
        

           
        }
    }
}