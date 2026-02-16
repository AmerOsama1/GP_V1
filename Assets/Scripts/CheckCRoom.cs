using UnityEngine;

public class CheckCRoom : MonoBehaviour
{
 public   bool [] isdone;

public GameObject miror;

void Update()
{
    bool allDone = true;

    for (int i = 0; i < isdone.Length; i++)
    {
        if (!isdone[i])
        {
            allDone = false;
            break;
        }
    }

    if (allDone)
    {
        miror.SetActive(false);
    }
}

}
