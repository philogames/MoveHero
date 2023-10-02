using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Classe que gerencia a partida atual
/// </summary>
public class GerentePartida : MonoBehaviour
{
    List<GameObject> bolas;
    public GameObject ModeloBola;
    Camera mainCam;
    public float ScoreLocal = 0;
    public float TempoInicialPartida = 300;
    float tempoAtual = 0;
    GerenciarUI gerenteUI;
    bool partidaIniciada = false;

    // Start is called before the first frame update
    void Start()
    {
        gerenteUI = GameObject.FindObjectOfType<GerenciarUI>();
        bolas = new List<GameObject>();
        Invoke("IniciarPartida", 3);
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (partidaIniciada)
        {
            tempoAtual += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(TempoInicialPartida - tempoAtual);
            gerenteUI.cronometroText.text = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        }

    }


    public void IniciarPartida()
    {
        if (GameData.Instance.DEBUG_MODE)
            GameData.Instance.GerarProximaPartidaAleatoria();

        InstanciarBolas();
        partidaIniciada = true;
    }


    public void AddScore(float scoreToAdd)
    {
        ScoreLocal += scoreToAdd;
        gerenteUI.SincronizarScore(ScoreLocal);
    }


    public void InstanciarBolas()
    {
        foreach(Bola_Info bola_info in GameData.Instance.Bolas_ProximaPartida)
        {
            GameObject temp_bolaObj = Instantiate(ModeloBola, this.transform);
            temp_bolaObj.GetComponent<Bola>().Inicializar(bola_info, mainCam);
            bolas.Add(temp_bolaObj);
        }
    }
}
