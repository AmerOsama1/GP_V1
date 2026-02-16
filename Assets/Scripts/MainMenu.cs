using UnityEngine;

public class MainMenu : MonoBehaviour
{
   
   


    public void ChangeGraphic()
    {
        int current = QualitySettings.GetQualityLevel();

        if (current == 0) 
        {
            QualitySettings.SetQualityLevel(1, true); 
        }
        else
        {
            QualitySettings.SetQualityLevel(0, true); 
        }
    }
    public void Reset()
    {
                    QualitySettings.SetQualityLevel(0, true); 

    }
    public void Exit()
    {
                   Application.Quit();

    }
}

