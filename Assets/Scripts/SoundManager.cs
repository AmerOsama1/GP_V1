using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header ("Sounds")]
    public AudioClip WalkOnWoodFloor;
    public AudioClip WalkOnWater;
    public AudioClip push;
    public AudioClip grab;
    public AudioClip Fire;
    public AudioClip Jump;

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlaySoundclip(AudioClip clip, bool IsOk ,AudioSource source)
    {
        source.clip = clip;

        if (IsOk)
        {
            source.Play();
        }
        else
        {
            source.Stop();
        }
    }
    public void PlaySoundclipOneShot(AudioClip clip,AudioSource source)
    {
        source.clip = clip;
        source.PlayOneShot(clip);



    }
}
