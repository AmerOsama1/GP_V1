using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    private AudioSource sc;

    private static Sprite[] cachedAyat;
    private static AudioClip[] cachedClips;

    private Sprite[] Ayat;
    private AudioClip[] clips;

    private int currentIndex = 0;
    private int max = 0;

    private float timer = 0f;
    private bool waiting = false;
    private bool finished = false;

    [SerializeField] private Image Current_Ayah;

    [SerializeField] private bool useAudio = true;
    [SerializeField] private float imageDelay = 4f;

    void Start()
    {
        ResetAndPlay();
    }

    private void ResetAndPlay()
    {
        finished = false;
        waiting = false;
        timer = 0f;

        sc = GetComponent<AudioSource>();
        if (sc != null)
        {
            sc.Stop();
        }

        if (cachedAyat == null || cachedAyat.Length == 0)
        {
            cachedAyat = Resources.LoadAll<Sprite>("Sour");
        }
        Ayat = cachedAyat;

        if (cachedClips == null || cachedClips.Length == 0)
        {
            cachedClips = Resources.LoadAll<AudioClip>("Audio");
        }
        clips = cachedClips;

        currentIndex = 0;
        max = useAudio ? Mathf.Min(Ayat.Length, clips.Length) : Ayat.Length;

        if (Ayat == null || Ayat.Length == 0)
        {
            Debug.LogError("No images found!");
            finished = true;
            return;
        }

        ShowCurrent();
    }

    private void ShowCurrent()
    {
        Current_Ayah.sprite = Ayat[currentIndex];

        if (useAudio && clips.Length > currentIndex)
        {
            sc.clip = clips[currentIndex];
            sc.Play();
        }
        else
        {
            timer = 0f;
        }

        waiting = true;
    }

    void Update()
    {
        if (finished || !waiting) return;

        if (useAudio && clips.Length > currentIndex)
        {
            if (!sc.isPlaying)
            {
                GoNext();
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= imageDelay)
            {
                GoNext();
            }
        }
    }

    private void GoNext()
    {
        waiting = false;
        currentIndex++;

        if (currentIndex >= max)
        {
            finished = true;
            SceneManager.LoadScene("4");
            return;
        }

        ShowCurrent();
    }
}