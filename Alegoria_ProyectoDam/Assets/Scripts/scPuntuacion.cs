using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scPuntuacion : MonoBehaviour
{
    private float puntuacion;
    private float temporizadorNivel;
    // Start is called before the first frame update
    void Start()
    {
      
        temporizadorNivel = 0f; //Inicializamos el temporizador
    }

    // Update is called once per frame
    void Update()
    {
        temporizadorNivel += Time.deltaTime; //Sigue sumando
    }

    public float getPuntuacion(){
        return puntuacion; //Devuelve la puntuación
    }

    public void  setPuntuacion(float puntuacionAdicional){ //Suma la puntuacion
        puntuacion += puntuacionAdicional;
    }

    public float getTemporizador(){
        return temporizadorNivel; //Retorna el temporizador
    }
    public float getPuntuacionFinalNivel(){
        return Mathf.Round(puntuacion - temporizadorNivel/10); //Retorna la puntuación final restando el 10% del tiempo gastado en el nivel y redondeando
    }
   
}
