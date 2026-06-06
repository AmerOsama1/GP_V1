using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCamera : MonoBehaviour
{
    public GameObject PlayerCam;
    public PlayerMovement movement;
    public EventSystem es;
    public GameObject TestCam;
    public GameObject MIssion;

    public GameObject firstSelected;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TestCam.SetActive(true);
            PlayerCam.SetActive(false);
            movement.enabled = false;
           es.SetSelectedGameObject(null);
            es.SetSelectedGameObject(firstSelected);
          Invoke("delay",2);
        }
    }

    public void restartMoveMent()
    {
        movement.enabled = true;
        PlayerCam.SetActive(true);
        TestCam.SetActive(false);
    }
   

    void delay(){
          MIssion.SetActive(true);
    }
}