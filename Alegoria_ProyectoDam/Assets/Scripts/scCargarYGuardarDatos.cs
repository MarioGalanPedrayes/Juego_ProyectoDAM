using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class scCargarYGuardarDatos : MonoBehaviour
{
    public scDatosUsuario scDatosUsuario; //Datos que recibiremos
    public Text txtFeedbackDatosGuardados; //Texto que mostrará el feedback de que los datos se han guardado
    private scClaseUsuario datosSerializados; //Datos que serializaremos (no pueden ser los recibidos porque estos heredan de MonoBehaviour)
    private scClaseUsuario [] arrayUsuarios; //Array que contendrá los usuarios
    private Boolean guardar = false; //¿Se tienen que guardar los datos?
    private Boolean yaGuardado=false; //¿Se han guardado los datos?
    private Boolean evitarRepetirDatos = false; //¿Se ha pulsado ya guardar?
    private scClaseUsuario [] arrayAuxiliar = new scClaseUsuario[5]; //Array auxiliar 
    public void GuardarDatos(){

        datosSerializados = new scClaseUsuario(scDatosUsuario); //Cambiamos de clase los datos recibidos
        ComprobarPuntuacion(); //Y comprobamos la puntuacion
        if(guardar){ //Si se debe guardar
            if(!evitarRepetirDatos){ //Si es la primera vez que eligen guardar datos
                txtFeedbackDatosGuardados.text = "SE HAN GUARDADO LOS DATOS";
                scAccesoDatos.GuardarDatosUsuario(arrayUsuarios); //Se pasa el array a serializar y guardar 
                evitarRepetirDatos = true; //Impide que la persona guarde los datos 2 veces al pulsar en "Guardar puntuación"
            }
            else{ //Si ya han guardado los datos
                txtFeedbackDatosGuardados.text = "YA SE HAN GUARDADO ESTOS DATOS";
            }
        }
        else{ //Si ComprobarDatos detecta que no es suficiente puntuación para guardar los datos
            txtFeedbackDatosGuardados.text = "PUNTUACIÓN INSUFICIENTE PARA ENTRAR AL RANKING";
        }
        
    }

    private void ComprobarPuntuacion(){ //Comprobamos la puntuacion
        
        int contador = 0;
        int contadorAux = 0;
        //El arrayAuxiliar nos servirá en caso de que ya estén guardados
        if(scAccesoDatos.CargarDatosUsuario() != null){ //Si existen ya datos de usuarios
           arrayUsuarios = scAccesoDatos.CargarDatosUsuario(); //Los cargamos
           arrayAuxiliar = scAccesoDatos.CargarDatosUsuario();
           
        }
        if(arrayUsuarios == null){ //Si no existen
            arrayUsuarios = scInicializarDatos.DatosIniciales(); //Los inicializamos
            arrayAuxiliar = scInicializarDatos.DatosIniciales(); 
        }
        
        Array.Sort(arrayUsuarios); //Lo ordenamos
        Array.Sort(arrayAuxiliar); 
        if(!evitarRepetirDatos){ //Evita que compruebe cada vez que se pulsa guardar datos los datos, lo que provoca la exception de salirse del array
            foreach (scClaseUsuario usuario in arrayUsuarios){ //Recorremos el array

                if(usuario.puntuacion <= datosSerializados.puntuacion && !yaGuardado){ //Si la puntuacion del usuario es menor  o igual a la que debemos guardar
                    guardar = true; //Le indicamos que se debe guardar
                    yaGuardado = true; //Y que ya se ha guardado (evita que sobreescriba todos los puntajes por debajo de este)
                    usuario.nombre = datosSerializados.nombre; //Sobreescribimos el valor de ese nombre
                    usuario.puntuacion = datosSerializados.puntuacion; //Y se su puntuacion
                    contadorAux = contador + 1;
                        /*Ahora está el problema de que ha sobreescrito encima del primero inferior que encuentra, pero debemos ir sobreescribiendo 
                        los valores hacia abajo, para ello creamos el array auxiliar*/
                }
                contador++;
            
            } 
            if(yaGuardado){ //Si ya se ha guardado
                try{
                    for(; contadorAux < arrayAuxiliar.Length; contadorAux++){ //Por la duración de contador hasta el final del array auxiliar
                        //Y sobreescribimos los usuarios, haciendo que bajen todos 1 en el ranking a partir del introducido
                        arrayUsuarios[contadorAux].nombre = arrayAuxiliar[contadorAux-1].nombre;
                        arrayUsuarios[contadorAux].puntuacion = arrayAuxiliar[contadorAux-1].puntuacion;
                    }
                }catch(IndexOutOfRangeException fueraDeRango){
                    Debug.LogError("FUERA DEL RANKING, EXCEPTION: " + fueraDeRango.Message);
                }
            }
        }
        
    }
}
