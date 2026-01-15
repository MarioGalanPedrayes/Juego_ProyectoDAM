using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scMostrarDatosUsuario : MonoBehaviour
{
    public Text datosUsuario; //Texto del canvas que mostrará el nombre de usuario y la puntuación
    public scDatosUsuario scDatosUsuario;
    // Start is called before the first frame update
    void Start()
    {
        datosUsuario.text = "El usuario " + scDatosUsuario.GetNombre() + " ha obtenido " + scDatosUsuario.GetPuntuacion() + " puntos."; //Plasmará el nombre del usuario y su puntuación
    }
    
}
