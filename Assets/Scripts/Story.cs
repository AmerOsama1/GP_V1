using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private AudioSource sc;

    private Sprite[] Ayat;
    private AudioClip[] clips;

    private int currentIndex = 0;

    [SerializeField] private Image Current_Ayah;

    [SerializeField] private bool useAudio = true; 
    [SerializeField] private float imageDelay = 4f;

    void Start()
    {
        sc = GetComponent<AudioSource>();

        Ayat = Resources.LoadAll<Sprite>("Sour/");
        clips = Resources.LoadAll<AudioClip>("Audio/");

        if (Ayat.Length == 0)
        {
            Debug.LogError("No images found!");
            return;
        }

        StartCoroutine(AutoPlay());
    }

    IEnumerator AutoPlay()
    {
        int max = useAudio ? Mathf.Min(Ayat.Length, clips.Length) : Ayat.Length;

        while (currentIndex < max)
        {
            Current_Ayah.sprite = Ayat[currentIndex];

            if (useAudio && clips.Length > currentIndex)
            {
                sc.clip = clips[currentIndex];
                sc.Play();

                yield return new WaitWhile(() => sc.isPlaying);
            }
            else
            {
                yield return new WaitForSeconds(imageDelay);
            }

            currentIndex++;
        }

        SceneManager.LoadScene("2");
    }
}
