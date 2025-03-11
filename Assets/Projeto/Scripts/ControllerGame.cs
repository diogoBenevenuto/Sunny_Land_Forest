using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerGame : MonoBehaviour
{

    private int score;
    public Text txtScore;
    public GameObject hitPrefab;


    public AudioSource fxGame;
    public AudioClip fxCenoura, fxExplosao;
   
    public void Pontuacao(int qtdPontos)
    {
        score  += qtdPontos;
        txtScore.text = score.ToString();

        fxGame.PlayOneShot(fxCenoura);
    }
}
