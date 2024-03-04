using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    private int score = 0;
    private int highscore = 0;

    // Singleton instance
    public static ScoreManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; // Set the instance
        // Load saved highscore
        highscore = PlayerPrefs.GetInt("Highscore", 0);

        UpdateScoreText();
        UpdateHighscoreText();
    }

    // Add points to the current score and update the text
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        // Update highscore if necessary
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            UpdateHighscoreText();
        }
    }

    // Update the score text
    void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }

    // Update the highscore text
    void UpdateHighscoreText()
    {
        highscoreText.text = "Pontuação Máxima: " + highscore.ToString();
    }
}
