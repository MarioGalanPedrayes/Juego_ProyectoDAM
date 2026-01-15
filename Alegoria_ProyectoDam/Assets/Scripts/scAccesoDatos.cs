using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
/*Esta clase se encarga de guardar y cargar datos del usuario en el ordenador
se realiza mediante serializacion con el objetivo de "cifrar" los datos guardados 
ya que en JSON sería fácilmente manipulables desde el editor de texto.
Es estática ya que la existencia de varios objetos de esta clase
daría muchisimos problemas a la hora de manejar datos además de que
nos permite acceder a la clase sin instanciar*/

public static class scAccesoDatos //No hace falta que hedere de MonoBehaviour
{ //No va asignado a ningun objeto

    private static string ruta = Application.persistentDataPath + "datosUsuarios.datos";
    private static string rutaJSON =  Application.persistentDataPath + "datosUsuarios.json";
    public static void GuardarDatosUsuario(scClaseUsuario[] datos){ //Recibimos un objeto scClase usuario
        scClaseUsuario []datosUsuario = datos; //y le damos valor

        FileStream fs = new FileStream(ruta, FileMode.OpenOrCreate) ; //creamos un flujo en la ruta indicada
        BinaryFormatter bf = new BinaryFormatter() ; //creamos un objeto binaryFormatter
        bf.Serialize(fs, datosUsuario); //serializamos los datos del usuario en el flujo
        fs.Close(); //Cerramos el archivo
    }

    public static scClaseUsuario[] CargarDatosUsuario(){
        if(File.Exists(ruta)){ //Si existe la ruta porque hay datos
            FileStream fs = new FileStream(ruta, FileMode.Open); //abre el flujo
            BinaryFormatter bf = new BinaryFormatter(); //crea un objeto BinaryFormatter
            scClaseUsuario[]datosUsuario = (scClaseUsuario[]) bf.Deserialize(fs); //Deserializa y da valor a datos usuario
            fs.Close();     //cierra el archivo
            return datosUsuario; //retornalo
        } //sino
        else{ //retorna null
            //crearDatos.ComprobarPuntuacion();
            return null;
        }
    }

    public static string getRutaDatosGuardados(){
        return ruta;
    }

}
