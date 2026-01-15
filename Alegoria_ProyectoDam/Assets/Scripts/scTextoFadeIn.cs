using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scTextoFadeIn : MonoBehaviour
{
//Código original en el siguiente post de unity https://discussions.unity.com/t/fading-in-out-gui-text-with-c-solved/613416

    private Text texto; //Texto a aparecer de fadeIn
    private Boolean textoVisible = false; //¿Está el texto visible?
    void Start(){
        texto = GetComponent<Text>(); //Asignamos el texto
        texto.color = Color.clear; //Y hacemos que desaparezca
    }
    void Update()
    {
        if(!textoVisible){ //Si el texto no esta visible
            StartCoroutine(AparecerTexto(1f)); //Que aparezca
            textoVisible = true; //E indicamos que ya esta visible
        }
        
    }

    public IEnumerator AparecerTexto(float t)
    { //Este método hace que el texto vaya cogiendo color
       
        while (texto.color.a < 1.0f) //Y mientras no sea visible
        {
            texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, texto.color.a + (Time.deltaTime / t)); //Va cogiendo el color
            yield return null;
        }
    }

}
