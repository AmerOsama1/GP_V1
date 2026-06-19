using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NewInputScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollSpeed = 0.5f;

    void Update()
    {
        float input = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.upArrowKey.isPressed)
                input += 1f;
            if (Keyboard.current.downArrowKey.isPressed)
                input -= 1f;
        }

        if (Gamepad.current != null)
        {
            float stickY = Gamepad.current.leftStick.y.ReadValue();
            if (Mathf.Abs(stickY) > 0.1f)
                input += stickY;

            if (Gamepad.current.dpad.up.isPressed)
                input += 1f;
            if (Gamepad.current.dpad.down.isPressed)
                input -= 1f;
        }
        else if (Joystick.current != null)
        {
            var stick = Joystick.current.stick;
            if (stick != null)
            {
                float stickY = stick.ReadValue().y;
                if (Mathf.Abs(stickY) > 0.1f)
                    input += stickY;
            }
        }

        if (Mathf.Abs(input) > 0.01f)
        {
            scrollRect.verticalNormalizedPosition += input * scrollSpeed * Time.deltaTime;
            scrollRect.verticalNormalizedPosition = Mathf.Clamp01(scrollRect.verticalNormalizedPosition);
        }
    }
}