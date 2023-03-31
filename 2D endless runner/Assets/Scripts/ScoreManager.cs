using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public bool gameOver = false;
    private float score = 0;
    public TMP_Text scoreMesh;

    // Update is called once per frame
    void Update()
    {
        // Adds to the score and updates text until game over
        if (!gameOver)
        {
            score += Time.deltaTime;
            scoreMesh.text = ((int)score).ToString();
        }
    }
}
