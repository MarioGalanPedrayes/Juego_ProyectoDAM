using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scInicializarDatos 
{
    public static scClaseUsuario[] DatosIniciales(){

        scClaseUsuario datosSerializados = new scClaseUsuario(); //Datos para iniciarlizar el array
        //No funciona sin pasarle datos, no tengo claro el porque
        scClaseUsuario [] arrayUsuarios = new scClaseUsuario[5]{datosSerializados,datosSerializados,datosSerializados,datosSerializados,datosSerializados};
        
       for(int i = 4; i>=0; i--){ //Añadimos usuarios iniciales
            arrayUsuarios[i] = new scClaseUsuario("Usuario " + i, i);
        }
        
        return arrayUsuarios;
       
    }
}
