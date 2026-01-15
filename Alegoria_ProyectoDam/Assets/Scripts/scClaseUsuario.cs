using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public  class scClaseUsuario : IComparable
{ /*Esta clase es pracitcamente igual que la de scDatosUsuario, pero se usa como paso ya que scDatosUsuario necesita hederar de MonoBehaviour
para poder ir linkeado a scripts y a un gameobject para que no se destruya, pero al hederar de esta clase no puede ser serializable, por lo 
que usamos esta clase como paso intermedio para serialzar*/
    public string nombre;
    public float puntuacion;

    public scClaseUsuario(){} //Constructor vacio
    public  scClaseUsuario(scDatosUsuario scDatosUsuario){
        //Contructor para cambiar de tipo scDatosUsuario a una clase que no heredar de MonoBehaviour (necesario para serializar)
        this.nombre = scDatosUsuario.nombre;
        this.puntuacion = scDatosUsuario.puntuacion;
        
    }
    public  scClaseUsuario(string nombreRecibido, float puntuacionRecibida){
        //Constructor para inicializar simplemente los datos 
        this.nombre = nombreRecibido;
        this.puntuacion = puntuacionRecibida;
        
    }
    
    int IComparable.CompareTo(object obj) //Para ordenar el array (código de internet modificado, fuente: https://www.youtube.com/watch?v=gQH0mak38WE&ab_channel=nicosiored)
    {
        scClaseUsuario temporal = (scClaseUsuario)obj;
        if(puntuacion < temporal.puntuacion){
            return 1;
        }

        if(puntuacion > temporal.puntuacion){
            return -1;
        }

        return 0;
        
    }
}
