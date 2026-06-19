using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class M22 : MonoBehaviour
{
   
       public EventSystem es;
    public GameObject firstSelected;

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
               es.SetSelectedGameObject(null);
            es.SetSelectedGameObject(firstSelected);
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
