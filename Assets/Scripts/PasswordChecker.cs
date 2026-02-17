using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class PasswordChecker : MonoBehaviour
{
        EventSystem eventSystem;

    public string correctPassword = "ABCDEFGHIJ";
    public InputField inputField;
    public Text percentageText;
    public GameObject CheckCanvas;
    public PlayerMovement PM;
   public GameObject firstSelected;

    public int maxLength = 10;

     void Awake()
    {
        eventSystem = EventSystem.current;
    }

    public void CheckPassword()
    {
        string playerInput = inputField.text;

        int correctLetters = 0;

        List<char> remainingLetters = new List<char>(correctPassword.ToCharArray());

        for (int i = 0; i < playerInput.Length; i++)
        {
            if (remainingLetters.Contains(playerInput[i]))
            {
                correctLetters++;
                remainingLetters.Remove(playerInput[i]); 
            }
        }

        float percentage = (float)correctLetters / correctPassword.Length * 100f;

percentageText.text = "Correct Password " + percentage.ToString("0") + "%";
    }

    public void WriteLetter(string letter)
    {
        if (inputField.text.Length >= maxLength)
            return;


        inputField.text += letter;
    }

    public void DeleteLetter()
    {
        if (inputField.text.Length <= 0)
            return;

        inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
                eventSystem.SetSelectedGameObject(firstSelected);
            CheckCanvas.SetActive(true);
            PM.enabled = false;
        }
    }
}
