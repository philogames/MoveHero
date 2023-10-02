using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;

/// <summary>
/// Classe para armazenar os dados de cada bola: Dados iniciais, de instanciamento, e também Dados de retorno, para alimentar o servidor
/// </summary>
[System.Serializable]
public class Bola_Info
{
    #region Dados Recebidos do Servidor
    [SerializeField]
    int ID;
    [SerializeField]
    public float launch_time = 1;
    [SerializeField]
    public Vector2 launch_coord = Vector2.zero;
    [SerializeField]
    public float speed = 1;
    [SerializeField]
    public Color color = Color.white;
    [SerializeField]
    public float size = 1;
    #endregion


    #region Dados a serem enviados para o servidor no final da partida
    //hit info
    [MMReadOnly]
    public float hit_time;
    [MMReadOnly]
    public Vector2 hit_coord;
    #endregion

   
    /// <summary>
    /// Construtor 1. A partir de uma bola_info
    /// </summary>
    /// <param name="bola"></param>
    public Bola_Info(Bola_Info bola)
    {
        this.ID = bola.ID;
        this.launch_time = bola.launch_time;
        this.launch_coord = bola.launch_coord;
        this.speed = bola.speed;
        this.color = bola.color;
        this.size = bola.size;
    }

    /// <summary>
    /// Construtor 2. Setando cada parametro individualmente.
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="launch_time"></param>
    /// <param name="launch_coord"></param>
    /// <param name="speed"></param>
    /// <param name="color"></param>
    /// <param name="size"></param>
    public Bola_Info(int ID, float launch_time, Vector2 launch_coord, float speed, Color color, float size)
    {
        this.ID = ID;
        this.launch_time = launch_time;
        this.launch_coord = launch_coord;
        this.speed = speed;
        this.color = color;
        this.size = size;
    }
}
