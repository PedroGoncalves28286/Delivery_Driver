using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    
    // Método chamado quando o jogo é iniciado
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Nenhuma lógica específica é executada quando o jogo é iniciado
    }
    public void StartButton()
    {
        
        // Carrega a cena "SampleScene"
        SceneManager.LoadScene("SampleScene");
        // FindObjectOfType<Timer>().StartTimer();

        
    }
    // Método chamado quando o botão de sair é pressionado
    public void QuitButton()
    {
        // Sai do aplicativo (apenas funciona em builds executáveis)
        Application.Quit();

        // Exibe uma mensagem no console indicando que o jogo terminou
        Debug.Log(" Fim de jogo");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
