using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource bgmPlayer;

    // Restarts the game and loads the scene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Goes back to the start screen
    public void Back()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
