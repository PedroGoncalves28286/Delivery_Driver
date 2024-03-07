using System;
using UnityEngine;
using static UnityEditor.Progress;

public class Delivery : MonoBehaviour
{
    // Vari�veis para cores do pacote e sem pacote

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    // Vari�vel para o atraso na destrui��o do pacote

    [SerializeField] float destroyDelay = 0.5f;

    // Vari�vel que indica se o objeto tem um pacote ou n�o
    Timer timer;//
    /// </summary>
    bool hasPackage;

    // Refer�ncia ao componente SpriteRenderer

    SpriteRenderer spriteRenderer;


    // M�todo chamado no in�cio do jogo
    void Start()
    {
        timer = FindObjectOfType<Timer>();///////////////////////////////////////////////
        // Obt�m o componente SpriteRenderer do objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // M�todo chamado quando outro objeto entra em colis�o com este objeto
    void OnTriggerEnter2D(Collider2D other)

    // Verifica se o objeto que colidiu � um pacote e se este objeto n�o tem um pacote
    {
        if (other.tag == "Package" && !hasPackage)
        {
            timer.CancelTimer();////////////////////////////////////////

            Debug.Log("Pachage picked up ");

            // Marca que este objeto tem um pacote agora

            hasPackage = true;
            // Muda a cor do objeto para indicar que tem um pacote

            spriteRenderer.color = hasPackageColor;
            // Destroi o pacote ap�s um atraso

            Destroy(other.gameObject, destroyDelay);
            // Adiciona pontos ao placar (exemplo: adicionar 10 pontos ao pegar um pacote)

            ScoreManager.Instance.AddScore(10);

          
        }

        if (other.tag == "Customer" && hasPackage)
        {
            // Informa que o pacote foi entregue

            Debug.Log("Package Deliverd ");

            // Marca que este objeto n�o tem mais um pacote

            hasPackage = false;

            // Muda a cor do objeto para indicar que n�o tem mais um pacote

            spriteRenderer.color = noPackageColor;
        }
    }
    void Update()////////////////////////////////
    {
        if (timer.isGameStarted)
        {
            // Handle timer-related logic if needed...
        }
    }
}

