using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerFade : MonoBehaviour
{

    public static ControllerFade instanceFade;

    public Image imagemFade;
    public Color corInicial, corFinal;
    public float duracaoFade;

    public bool isFade;
    private float tempo;

    void Awake()
    {
        instanceFade = this;   
    }

    IEnumerator InicioFade() // IEnumerator para poder startar uma corrita para executar  codigo
    {
        isFade = true;
        tempo = 0f;

        while (tempo <= duracaoFade)
        {
            imagemFade.color = Color.Lerp(corInicial, corFinal, tempo / duracaoFade);
            tempo = tempo + Time.deltaTime;
            yield return null;
        }

        isFade = false;
    }

    void Start()
    {
        StartCoroutine(InicioFade());
    }


    void Update()
    {
        
    }
}
