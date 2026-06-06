using UnityEngine;

public class ObjectCycler : MonoBehaviour
{
    public GameObject[] objects;
    private int currentIndex = -1;

    void Start()
    {
        foreach (var obj in objects)
            obj.SetActive(false);
    }

    public void CycleNext()
    {
        if (currentIndex >= 0)
            objects[currentIndex].SetActive(false);

        currentIndex = (currentIndex + 1) % objects.Length;
        objects[currentIndex].SetActive(true);
    }
    public void Toggle(GameObject content)
{
    content.SetActive(!content.activeSelf);
}
}