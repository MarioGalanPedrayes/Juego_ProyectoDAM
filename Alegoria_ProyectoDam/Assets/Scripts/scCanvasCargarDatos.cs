using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class scCanvasCargarDatos : MonoBehaviour
{
      public Text textoAMostrar; //Texto donde se mostrará el ranking
      private scClaseUsuario [] datosSerializados; //Datos guardados del usuario
      public scDatosUsuario scDatosUsuario; //Datos actuales del usuario
    void Start()
    {
       cargarDatosCanvas();
               
    }

    public void cargarDatosCanvas(){
        //Cargamos los datos del usuario
        datosSerializados = scAccesoDatos.CargarDatosUsuario(); 
        textoAMostrar.text = ""; //Inicializamos el texto
        int contador = 1; //El ranking siempre tendrá 5 usuarios
        if(datosSerializados == null){ //Si no hay datos cargados 
            datosSerializados =   scInicializarDatos.DatosIniciales(); //Inicializalos
        }
        Array.Sort(datosSerializados); //Ordenalos
        foreach (scClaseUsuario usuario in datosSerializados){ //Por cada usuario en los datos serializados
            scDatosUsuario.nombre = usuario.nombre; //Introduce en los datos actuales el nombre
            scDatosUsuario.puntuacion = usuario.puntuacion; // la puntuación
               
            textoAMostrar.text += contador + "º: El usuario " + scDatosUsuario.nombre + " ha obtenido " +  scDatosUsuario.puntuacion + " puntos. \n"; //Y plásmalo
            contador++; //Sigo contado
        }
    }
    /*Lo hago así debido a que unity necesita un linkeo entre los datos serializables y el texto, que es scDatosUsuario*/

}
