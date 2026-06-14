using UnityEngine;
using System.Collections;

public class ShowForSeconds : MonoBehaviour
{
     GameObject target;
    public float duration = 1f;

    public void Show(GameObject obj)
    {
        target = obj;
        StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        target.SetActive(true);
        yield return new WaitForSeconds(duration);
        target.SetActive(false);
    }
}