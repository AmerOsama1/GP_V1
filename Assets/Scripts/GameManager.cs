using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuUI;
        [SerializeField] private GameObject Fade;
  [SerializeField] PlayerMovement pm;


    bool ISShow;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         pm.enabled=false;
                                                                     UnScale();
        Fade.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       for (int i = 0; i < 20; i++)
    {
        if (Input.GetKeyDown("joystick button " + i))
        {
            Debug.Log("Pressed: joystick button " + i);
        }
    }
        if ((Input.GetKeyDown(KeyCode.Escape))||Input.GetButtonDown("Cancel"))
        {
            if(ISShow){
                MainMenuUI.SetActive(true);
                ISShow=false;
Scale();
            }
            else
            {
                                MainMenuUI.SetActive(false);
                                                ISShow=true;
UnScale();

            }
        }
    }
    public void Scale(){
                Time.timeScale=0;
                
    }
      public void UnScale(){
                                                                        Time.timeScale=1;

    }
    public void EndNotes()
    {
        pm.enabled=true;
    }
    }
