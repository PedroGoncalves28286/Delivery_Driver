using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    
    // M�todo chamado quando o jogo � iniciado
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Nenhuma l�gica espec�fica � executada quando o jogo � iniciado
    }
    public void StartButton()
    {
        
        // Carrega a cena "SampleScene"
        SceneManager.LoadScene("SampleScene");
        // FindObjectOfType<Timer>().StartTimer();

        
    }
    // M�todo chamado quando o bot�o de sair � pressionado
    public void QuitButton()
    {
        // Sai do aplicativo (apenas funciona em builds execut�veis)
        Application.Quit();

        // Exibe uma mensagem no console indicando que o jogo terminou
        Debug.Log(" Fim de jogo");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
