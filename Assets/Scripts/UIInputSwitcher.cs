using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIInputSwitcher : MonoBehaviour
{
    EventSystem eventSystem;
    GameObject firstSelected;

    void Awake()
    {
        eventSystem = EventSystem.current;
    }

    void Update()
    {

        JoystickController();
        
        if(CheckContoller()){KeyboardConroller();}
     else{ MouseConroller();}
     
    }

void JoystickController()
{
    if (Joystick.current == null) return;

   
    if (Mathf.Abs(Joystick.current.stick.ReadValue().x) > 0.2f ||
        Mathf.Abs(Joystick.current.stick.ReadValue().y) > 0.2f ||
        Joystick.current.trigger.wasPressedThisFrame)
    {
        if (eventSystem.currentSelectedGameObject == null && firstSelected != null)
        {
            eventSystem.SetSelectedGameObject(firstSelected);
        }
    }
}

    bool CheckContoller()
    {
        return (Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame);

    }
    void KeyboardConroller()
    {
            if (eventSystem.currentSelectedGameObject == null && firstSelected != null)
            {
                  firstSelected = eventSystem.firstSelectedGameObject;
                 eventSystem.SetSelectedGameObject(firstSelected);
            }
    }
     void MouseConroller()
    {
         if (Mouse.current != null && Mouse.current.delta.ReadValue() != Vector2.zero)
        {
            firstSelected = eventSystem.firstSelectedGameObject;
        }
    }

}
