using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic bgm;

    private void Awake()
    {
        // Allows the bgm to play and loop
        if (bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Stops the bgm going back to the start 
    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name == "StartScreen")
        {
            GetComponent<AudioSource>().Stop();
        }
        else if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
