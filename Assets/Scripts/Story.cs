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

    void Start()
    {
        sc = GetComponent<AudioSource>();

        Ayat = Resources.LoadAll<Sprite>("Sour/");
        clips = Resources.LoadAll<AudioClip>("Audio/");

        if (Ayat.Length == 0 || clips.Length == 0)
        {
            Debug.LogError("No images or audio found!");
            return;
        }

        StartCoroutine(AutoPlay());
    }

    IEnumerator AutoPlay()
    {
        int max = Mathf.Min(Ayat.Length, clips.Length);

        while (currentIndex < max)
        {
            Current_Ayah.sprite = Ayat[currentIndex];

            sc.clip = clips[currentIndex];
            sc.Play();

            yield return new WaitWhile(() => sc.isPlaying);

            currentIndex++;
        }

        SceneManager.LoadScene("2");
    }
}
