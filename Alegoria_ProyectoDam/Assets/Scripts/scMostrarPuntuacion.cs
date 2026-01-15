using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scMostrarPuntuacion : MonoBehaviour
{
    public scPuntuacion puntuacion; //GameObject con el script scPuntuacion que guardará y modificará la puntuación
    public Text textoPuntuacion; //Texto del canvas que mostrará la puntuación

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoPuntuacion.text = "Puntuación del nivel: " + Mathf.Round(puntuacion.getPuntuacion()); //Actualiza la puntuación y la redondea
    }
}
