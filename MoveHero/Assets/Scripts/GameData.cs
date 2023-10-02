using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

/// <summary>
/// Classe Singleton para armazenar informações persistentes entre partidas. 
/// Possui um modo DEBUG para testes, que gera uma lista de bolas aleatoriamente de acordo com os parametros. 
/// </summary>

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
 

    private int idJogador;
    private int ScoreTotal  = 0;
    private int FaseAtual  = 0;

    /// <summary>
    /// Lista que armazena as bolas da próxima partida, de acordo com dados do Servidor.
    /// Caso DEBUG_MODE esteja ativo, essa lista será preenchida aleatoriamente
    /// </summary>
    public List<Bola_Info> Bolas_ProximaPartida; 

    [Tooltip("Ative para gerar a lista de bolas aleatoriamente, sem acessar o servidor")]
    public bool DEBUG_MODE = false;
    #region DEBUG PARAMETERS
    [MMCondition("DEBUG_MODE", true)]
    public Vector2 qtdBolas_minMax;
    [MMCondition("DEBUG_MODE", true)]
    public Vector2 speed_minMax;
    [MMCondition("DEBUG_MODE", true)]
    public Vector2 size_minMax;
    [MMCondition("DEBUG_MODE", true)]
    public Vector2 launchCoord_min;
    [MMCondition("DEBUG_MODE", true)]
    public Vector2 launchCoord_max;
    [MMCondition("DEBUG_MODE", true)]
    public float minDelayEntreBolas = 0.5f;
    [MMCondition("DEBUG_MODE", true)]
    public bool randomColor = false;
    #endregion

    /// <summary>
    /// Adiciona o Score da Partida ao Score Total do jogador
    /// </summary>
    /// <param name="valor">Score ganho na última partida</param>
    public void AddTotalScore(int valor)
    {
        ScoreTotal += valor;
    }

    /// <summary>
    /// Adiciona uma Fase
    /// </summary>
    public void AddFase()
    {
        FaseAtual++;
    }


    private void Awake()
    {
        //garante que a classe seja um singleton
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    /// <summary>
    /// Gerar aleatóriamente uma lista de bolas para testar a partida localmente, sem acessar o servidor.
    /// Só funciona caso o DEBUG_MODE esteja ativado.
    /// </summary>
    public void GerarProximaPartidaAleatoria()
    {
        if (DEBUG_MODE)
        {

            //define uma quantidade aleatoria de bolas para serem instanciadas de acordo com o min e max permitido
            int temp_QtdBolas = Random.Range((int)qtdBolas_minMax.x, (int)qtdBolas_minMax.y);

            //apaga a lista de bolas anterior;
            Bolas_ProximaPartida.Clear();

            //gera as bolas com propriedades aleatórias definidas pelas variaveis de controle do DEBUG_MODE
            for (int i = 0; i < temp_QtdBolas; i++)
            {
                //coordenada inicial aleatoria
                Vector2 _temp_launchCoord = new Vector2(Random.Range(launchCoord_min.x, launchCoord_max.x), Random.Range(launchCoord_min.y, launchCoord_max.y));

                //velocidade inicial aleatória
                float _temp_speed = Random.Range(speed_minMax.x, speed_minMax.y);

                //cor branca
                Color _temp_color = Color.white;
                if (randomColor)//caso a cor tbm esteja definica como aleatória, então gerar uma cor aleatória
                    _temp_color = new Color(Random.value, Random.value, Random.value);

                //tamanho aleatório
                float _temp_size = Random.Range(size_minMax.x, size_minMax.x);

                //cria uma instancia Bola_Info para armazenar os dados da bola
                Bola_Info b = new Bola_Info(i, i * minDelayEntreBolas, _temp_launchCoord, _temp_speed, _temp_color, _temp_size);

                //adiciona os dados da bola recem gerados para a lista que será utilizada pelo Gerenciador de Partida
                Bolas_ProximaPartida.Add(b);

            }
        }
    }
 
}
