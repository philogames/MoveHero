using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe para gerenciar as bolas instanciadas no jogo.
/// </summary>
public class Bola : MonoBehaviour
{

    //dados da bola
    Bola_Info info;

    //spriterenderer da bola
    SpriteRenderer rend;

    //collider da bola
    Collider2D colisor;

    //amazena o tempo que a bola foi iniciada. Essa variável será comparada com o tempo atual para definir a propriedade "hit_time"
    float timeOnEnable;

    //flag para sinalizar que o jogador conseguir acertar essa bola
    bool playerAcertou = false;

    //valor de score adicionado ao acertar a bola
    public float scoreToAdd = 10;

    /// <summary>
    /// Preparar a bola para ser iniciada.
    /// </summary>
    /// <param name="bola">Dados da bola vindos do servidor</param>
    /// <param name="cam">Referencia da camera principal</param>
    public void Inicializar(Bola_Info bola, Camera cam)
    {
        //desabilita o sprite
        rend = gameObject.GetComponent<SpriteRenderer>();
        rend.enabled = false;

        //desabilita o collider (para evitar que o jogador clique sem querer)
        colisor = gameObject.GetComponent<CircleCollider2D>();
        colisor.enabled = false;

        //seta a bola com as informações vindas do servidor
        info = new Bola_Info(bola);

        //seta a cor (color)
        rend.color = info.color;

        //seta o tamanho (size)
        transform.localScale = Vector3.one * info.size;

        //calcula a posição inicial (launch_coord)
        //ScreenToWorldPoint transforma para uma posição nas coordenadas da tela
        //É preciso somar o valor (Vector2.up * cam.pixelHeight) para dar um offset de acordo com a resolução da camera, pois o ponto (0, 0) é no canto inferior esquerdo.
        Vector2 screenPos = cam.ScreenToWorldPoint(info.launch_coord + (Vector2.up * cam.pixelHeight));

        //seta a posição inicial (launch_coord)
        //o valor da coordenada Z é 0.5 para que a posicao das bolas estejam numa zona favorável para colisão com raycasts
        transform.position = new Vector3(screenPos.x, screenPos.y, 0.5f);

        //inicia a coroutine para aplicar os parametros na bola
        StartCoroutine(IniciarMovimento());
       
    }

 


    /// <summary>
    /// Inicia o movimento da bola.
    /// </summary>
    IEnumerator IniciarMovimento()
    {
        //aguardar X segundos, respeitando o launch_time da bola
        yield return new WaitForSeconds(info.launch_time);

        //ativa o sprite
        rend.enabled = true;

        //ativa o collider
        colisor.enabled = true;

        //armazenar o tempo do jogo que a bola foi instanciada, para mais tarde calcular o tempo em que o jogador acertou
        timeOnEnable = Time.time;

        //Iniciar, de fato, a movimentação
        StartCoroutine(Movimentar());
    }

    /// <summary>
    /// Função recursiva para movimentar a bola para baixo
    /// </summary>
    /// <returns></returns>
    IEnumerator Movimentar()
    {
        //aplica a movimentação
        this.gameObject.transform.position += Vector3.down * info.speed * Time.deltaTime;

        //espera até o fim do frame
        yield return new WaitForEndOfFrame();

        //recursão
        StartCoroutine(Movimentar());
    }


    /// <summary>
    /// Armazena os dados adicionais que serão enviados ao servidor quando o jogador acertar a bola.
    /// </summary>
    public void PlayerAcertou()
    {
        //armazena coordenada atual da bola
        info.hit_coord = transform.position;

        //calcula o tempo de vida da bola
        info.hit_time = Time.time - timeOnEnable;

        //flag para sinalizar que o jogador acertou a bola
        playerAcertou = true;

        //desativa a bola
        gameObject.SetActive(false);

    }
 
}
