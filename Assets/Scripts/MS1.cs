using UnityEngine;

public class MS1 : MonoBehaviour
{
    public bool[] check;
    public GameObject win, lose;
   int index =0;
    public void SetCheck(int index)
    {
        check[index] = true;
    }
       public void SetCheckL(int index)
    {
        check[index] = false;
     
    }

       public void setIndex()
    {
        index++;
        if(index == check.Length){
        CheckAll();}
    }


    private void CheckAll()
    {
        foreach (bool b in check)
        {
            if (!b)
            {
                lose.SetActive(true);
                return;
            }
        }

        win.SetActive(true);
    }
}   