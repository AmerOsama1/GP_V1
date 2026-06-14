using UnityEngine;
using TMPro;

public class CheckKey : MonoBehaviour
{
     public TMP_InputField inputField;
    public GameObject correctObj;
      public GameObject correctObj1;
      public GameObject current;
    public GameObject wrongObj;
    public int maxLength = 10;
     public void WriteLetter(string letter)
    {
        if (inputField.text.Length >= maxLength) return;
        inputField.text += letter;
    }

    public void DeleteLetter()
    {
        if (inputField.text.Length <= 0) return;
        inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
    }

    public void Check()
    {
        if (inputField.text == "AES-256-CYBER")
        {
            correctObj.SetActive(true);
            current.SetActive(false);
            correctObj1.SetActive(true);
            wrongObj.SetActive(false);
        }
        else
        {
            correctObj.SetActive(false);
            wrongObj.SetActive(true);
        }
    }
}
