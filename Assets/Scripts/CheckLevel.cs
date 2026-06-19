using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckLevel : MonoBehaviour
{
        public string nameOfLevel;

   
    void OnTriggerEnter(Collider other)
    {
          if(other.CompareTag("Player")){

        int savedLevel = PlayerPrefs.GetInt(nameOfLevel, -1);
        savedLevel +=1; 
       PlayerPrefs.SetInt(nameOfLevel,savedLevel);
        PlayerPrefs.Save();
        SceneManager.LoadScene("5");
    }
    }
}
