using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoChangeScene : MonoBehaviour
{
    [SerializeField] private float delay = 20f;

    void Start()
    {
        Invoke(nameof(ChangeScene), delay);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            CancelInvoke(nameof(ChangeScene));
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("4");
    }
}