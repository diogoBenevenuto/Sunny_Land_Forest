using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlataforma : MonoBehaviour
{
    public Transform plataforma, pontoA, pontoB;
    public float velocidadePlataforma;

    public Vector3 pontoDestino;

    public GameObject player;
    void Start()
    {
        plataforma.position = pontoA.position;
        pontoDestino = pontoB.position;
    }

    
    void Update()
    {
        if(plataforma.position == pontoA.position)
        {
            pontoDestino = pontoB.position;
        }

        if(plataforma.position == pontoB.position)
        {
            pontoDestino = pontoA.position;
        }

        plataforma.position = Vector3.MoveTowards(plataforma.position, pontoDestino, velocidadePlataforma);
    }
}
