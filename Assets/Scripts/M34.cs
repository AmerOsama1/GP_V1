using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class M34 : MonoBehaviour
{
   public EventSystem es;
    public TMP_InputField inputField;
    public GameObject correctObj;
        public GameObject GREEN;
    public GameObject wrongObj;
    public GameObject firstSelected;

    public GameObject word;

    public string targetWord = "ECGUCT_QRGPU_FIAT";

    private char[] currentLetters;
 
    void Start()
    {
        currentLetters = new char[targetWord.Length];
        for (int i = 0; i < currentLetters.Length; i++)
        {
            currentLetters[i] = ' ';
        }
        inputField.text = new string(currentLetters);
    }

    public void WriteLetter(int index)
    {
        if (index < 0 || index >= targetWord.Length) return;
        currentLetters[index] = targetWord[index];
        inputField.text = new string(currentLetters);

        if (inputField.text == targetWord)
        {
word.SetActive(true);
        }
    }

    public void DeleteLetter(int index)
    {
        if (index < 0 || index >= targetWord.Length) return;
        currentLetters[index] = ' ';
        inputField.text = new string(currentLetters);
    }

    public void Check()
    {
        if (inputField.text == targetWord)
        {
            es.SetSelectedGameObject(null);
            es.SetSelectedGameObject(firstSelected);
            correctObj.SetActive(true);
            wrongObj.SetActive(false);
            GREEN.SetActive(true);
        }
        else
        {
            correctObj.SetActive(false);
            wrongObj.SetActive(true);
        }
    }
}
