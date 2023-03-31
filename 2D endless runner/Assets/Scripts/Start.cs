using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Loads the next scene
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Quits game
    public void QuitGame()
    {
        Application.Quit();
    }
}
