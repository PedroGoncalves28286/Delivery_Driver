using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;// Refer�ncia ao texto que exibe a pontua��o atual
    public Text highscoreText;// Refer�ncia ao texto que exibe a pontua��o m�xima

    private int score = 0;// Pontua��o atual
    private int highscore = 0;// Pontua��o m�xima

   // inst�ncia de Singleton
    public static ScoreManager Instance { get; private set; }

    // Chamado antes da primeira atualiza��o de quadro 
    void Start()
    {
        Instance = this; //Define a inst�ncia 

      //carrega a pontua��p maxima salva
        highscore = PlayerPrefs.GetInt("Highscore", 0);

        UpdateScoreText();
        UpdateHighscoreText();
    }

   //Adiciona pontos � pontua��o atual e atualiza o texto 
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

       //atualiza a pintua��o m�xima , se necess�rio 
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
            UpdateHighscoreText();
        }
    }

   // Atualiza o texxto da pontua��o
    void UpdateScoreText()
    {
        scoreText.text = "Pontua��o: " + score.ToString();
    }

   // Atualiza o texto da pontua��p m�xima 
    void UpdateHighscoreText()
    {
        highscoreText.text = "Pontua��o M�xima: " + highscore.ToString();
    }
}
