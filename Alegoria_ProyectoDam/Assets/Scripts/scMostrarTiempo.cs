using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scMostrarTiempo : MonoBehaviour
{
    public scPuntuacion temporizador; //GameObject con el script scPuntuacion que guardará y modificará la puntuación
    public Text textoTemporizador; //Texto del canvas que mostrará la puntuación

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            textoTemporizador.text = "Tiempo: " + Mathf.Round(temporizador.getTemporizador()); //Actualiza el temporizador y lo redondemos
    }
}
