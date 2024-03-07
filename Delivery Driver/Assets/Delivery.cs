using System;
using UnityEngine;
using static UnityEditor.Progress;

public class Delivery : MonoBehaviour
{
    // Variáveis para cores do pacote e sem pacote

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    // Variável para o atraso na destruição do pacote

    [SerializeField] float destroyDelay = 0.5f;

    // Variável que indica se o objeto tem um pacote ou não
    Timer timer;//
    /// </summary>
    bool hasPackage;

    // Referência ao componente SpriteRenderer

    SpriteRenderer spriteRenderer;


    // Método chamado no início do jogo
    void Start()
    {
        timer = FindObjectOfType<Timer>();///////////////////////////////////////////////
        // Obtém o componente SpriteRenderer do objeto
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Método chamado quando outro objeto entra em colisão com este objeto
    void OnTriggerEnter2D(Collider2D other)

    // Verifica se o objeto que colidiu é um pacote e se este objeto não tem um pacote
    {
        if (other.tag == "Package" && !hasPackage)
        {
            timer.CancelTimer();////////////////////////////////////////

            Debug.Log("Pachage picked up ");

            // Marca que este objeto tem um pacote agora

            hasPackage = true;
            // Muda a cor do objeto para indicar que tem um pacote

            spriteRenderer.color = hasPackageColor;
            // Destroi o pacote após um atraso

            Destroy(other.gameObject, destroyDelay);
            // Adiciona pontos ao placar (exemplo: adicionar 10 pontos ao pegar um pacote)

            ScoreManager.Instance.AddScore(10);

          
        }

        if (other.tag == "Customer" && hasPackage)
        {
            // Informa que o pacote foi entregue

            Debug.Log("Package Deliverd ");

            // Marca que este objeto não tem mais um pacote

            hasPackage = false;

            // Muda a cor do objeto para indicar que não tem mais um pacote

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

