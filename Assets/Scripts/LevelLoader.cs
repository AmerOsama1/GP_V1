using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject player;
    public string nameOfLevel;
    public string Lvl;
    public SceneTimer  st;
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


    //   if(nameOfLevel =="ENCRYPTION"){
    //     if(savedLevel>=2){
    //      st.totalTime=90;}
    //   }
    }

    public void GOTOMAiN()
    {
        SceneManager.LoadScene(Lvl);
         int savedLevel = PlayerPrefs.GetInt(nameOfLevel, -1);
         savedLevel +=1; 
       PlayerPrefs.SetInt(nameOfLevel,savedLevel);
        PlayerPrefs.Save();
    }
  
  public void goToMainWithoutSave(){
    SceneManager.LoadScene(Lvl);
  }
}