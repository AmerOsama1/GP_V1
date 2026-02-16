using TMPro;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    [SerializeField] Transform[] Frame;
    [SerializeField] TextMeshProUGUI Time_text;
    [SerializeField] float time;
    [SerializeField] bool isStart;
    [SerializeField] GameObject Timer;
    [SerializeField] GameObject frameHolder;

    [SerializeField] RoomOneController rc;


    private void Update()
    {
        if (isStart)
        {
            startTime();
            updateText();
        }
        if (time <= 0)
        {
            time = 10;
            rc.changeSpriteToNormal();
                int rand =Random.Range(0, Frame.Length);
            rc.correctFrame = Frame[rand].gameObject;
            rc.changeSprite();

            Timer.SetActive(false);
            frameHolder.SetActive(false);

            isStart = false;
            foreach (var item in Frame)
            {



                item.transform.rotation = Quaternion.Euler(
                   item.transform.rotation.eulerAngles.x,
                    0,
                   item.transform.rotation.eulerAngles.z
                );
            }
        }
    }
    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var item in Frame)
            {
                frameHolder.SetActive(true);

                item.transform.rotation = Quaternion.Euler(
                   item.transform.rotation.eulerAngles.x,
                    180,
                   item.transform.rotation.eulerAngles.z
                );
            }
            isStart = true;
            
        }
    }
    

    void startTime()
    {
        time -= 1 * Time.deltaTime;
        Timer.SetActive(true);

    }
    void updateText()
    {
        Time_text.text = time.ToString("0");
    }

}
