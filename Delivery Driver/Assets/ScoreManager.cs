using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;// Referência ao texto que exibe a pontuação atual
    public Text highscoreText;// Referência ao texto que exibe a pontuação máxima

    private int score = 0;// Pontuação atual
    private int highscore = 0;// Pontuação máxima

   // instãncia de Singleton
    public static ScoreManager Instance { get; private set; }

    // Chamado antes da primeira atualização de quadro 
    void Start()
    {
        Instance = this; //Define a instãncia 

      //carrega a pontuaçãp maxima salva
        highscore = PlayerPrefs.GetInt("Highscore", 0);

        UpdateScoreText();
        UpdateHighscoreText();
    }

   //Adiciona pontos á pontuação atual e atualiza o texto 
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

       //atualiza a pintuação máxima , se necessário 
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            UpdateHighscoreText();
        }
    }

   // Atualiza o texxto da pontuação
    void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }

   // Atualiza o texto da pontuaçãp máxima 
    void UpdateHighscoreText()
    {
        highscoreText.text = "Pontuação Máxima: " + highscore.ToString();
    }
}
