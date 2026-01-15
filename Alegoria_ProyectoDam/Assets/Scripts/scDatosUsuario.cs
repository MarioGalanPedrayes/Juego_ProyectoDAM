using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scDatosUsuario : MonoBehaviour
{

    public string nombre; //Nombre del usuario
    public float puntuacion = 0;  //Puntuación del usuario
    void Awake() { 
        DontDestroyOnLoad(this); //Indico que no lo destruya al cargar la escena
    }
    
    public void SetNombre(string nombreRecibido){ //Damos valor al nombre
        nombre = nombreRecibido; 
    } 
    public string GetNombre(){  //Devuelvo el nombre
        return nombre; 
        
    } 
    public void SetPuntuacion(float puntuacionRecibida){  //Damos valor a la puntuación
        puntuacion += puntuacionRecibida; //Sumamos la puntuación del nivel
    } 
    public float GetPuntuacion(){  //Recogemos la puntuación
        return puntuacion; 
    } 
    public void ReiniciarPuntuacion(){
        puntuacion = 0;
    }
}
