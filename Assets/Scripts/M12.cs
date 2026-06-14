using UnityEngine;
using UnityEngine.SceneManagement;
public class M12 : MonoBehaviour
{
        public bool[] check;
        int index = 0;
      public LevelLoader lvl;
  


        public void setIndex()
    {
        index++;
       
    }
    public void changeScene(){

         if (index == check.Length)
        {
           lvl.GOTOMAiN();
        }
    }

    

    
 
}
