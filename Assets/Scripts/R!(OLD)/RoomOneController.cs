using UnityEngine;

public class RoomOneController : MonoBehaviour
{
    public GameObject correctFrame;
    public GameObject drawer;
    public GameObject letterA;
    [SerializeField] GameObject door;
    [SerializeField] Material mt,mt1;


    bool solved = false;

    void Start()
    {
        drawer.SetActive(false);
        letterA.SetActive(false);
    }

    public void ClickOnFrame(GameObject frame)
    {
        if (solved) return;

        if (frame == correctFrame)
        {
            door.SetActive(false);
            solved = true;
            drawer.SetActive(true);
            letterA.SetActive(true);
            Debug.Log("Room 1 Solved - Letter A");
        }
        else
        {
            Debug.Log("Wrong frame - observe carefully");
        }
    }

   public void changeSprite()
    {
        correctFrame.GetComponent<MeshRenderer>().material = mt;
    }
    public void changeSpriteToNormal()
    {
        correctFrame.GetComponent<MeshRenderer>().material = mt1;
    }
}
