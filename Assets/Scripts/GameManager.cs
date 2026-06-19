using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
        EventSystem eventSystem;

    [SerializeField] private GameObject MainMenuUI;
        [SerializeField] private GameObject Fade;
         [SerializeField] private GameObject firstSelected;
  [SerializeField] PlayerMovement pm;


    bool ISShow;
    void Start()
    {
        if(pm!=null){
         pm.enabled=false;}
         
          UnScale();
        Fade.SetActive(true);
        MainMenuUI.SetActive(false);
    }

    void Awake()
    {
        eventSystem = EventSystem.current;
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
                 eventSystem.SetSelectedGameObject(firstSelected);
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
