using UnityEngine;
using TMPro;
public class MS5 : MonoBehaviour
{
    public bool[] check;
    public GameObject win;
    int index = 0;
    public TextMeshProUGUI Number_attacks_text;
     public TextMeshProUGUI all_Number_attacks_text;
    int Number_attacks;

    public void SetCheck(int index)
    {
        check[index] = true;
    }

    public void SetNumber_attacks(){
        Number_attacks++;
        updateUI();

    }
    public void updateUI(){
        Number_attacks_text.text=Number_attacks.ToString();
    }
   
   

    public void setIndex()
    {
        index++;
        if (index == check.Length)
        {
            CheckAll();
        }
    }

    private void CheckAll()
    {
        all_Number_attacks_text.text=Number_attacks.ToString();
        win.SetActive(true);
    }
}
