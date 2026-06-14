using UnityEngine;
using TMPro;

public class M22 : MonoBehaviour
{
   
        public bool[] check;
        int index = 0;
      public GameObject WIN,green;
 int fake;
  int err;

          public TextMeshProUGUI fake_text;
     public TextMeshProUGUI err_text;

       
      


        public void setIndex()
    {
        index++;    
        Debug.Log(index);
         if (index == check.Length)
        {
           WIN.SetActive(true);
           green.SetActive(true);
        }
       
    }

    
    public void updatefake(){
        fake++;
        updateUI();
    }

    public void updateUI(){
        fake_text.text=fake.ToString();
    }


      public void updateErr(){
        err++;
        updateUIERR();
    }
    
    public void updateUIERR(){
        err_text.text=err.ToString();
    }
   
  

}
