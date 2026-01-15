using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SFB;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class scImportarDatosJSON : MonoBehaviour
{
    //Clase de la libreria importada StandAloneFileBrowser para indicar la extension de los archivos
    private ExtensionFilter[] extensionArchivo = new []{new ExtensionFilter("Archivos JSON","json")}; //¿Qué extensión tiene el archivo? en nuestro caso JSON
    public Text txtMensaje; //Texto creado en principio para mostrar errores
    public void ImportarDatos(){
        //Indicamos la ruta, que abrirá un explorador de arhivos donde el usuario añadirá el json
        string [] path = StandaloneFileBrowser.OpenFilePanel("Seleccione un JSON para cargar el ranking",Application.persistentDataPath, extensionArchivo, false);
        try{ //Intenta
            //Si existe ese archivo
            if(path.Length != 0){      
                if(Path.GetExtension(path[0]).ToLower() == ".json"){ //¿La extensión es .JSON?
                    if(File.Exists(path[0])){ //¿Existe el archivo?
                        string[] datosJSON  = File.ReadAllLines(path[0]); //Lee las lineas del JSON y guardalas en un array de string
                        scClaseUsuario[] datosUsuarios = new scClaseUsuario[5]; //El array que pasaremos a guardar datos con los datos
                        int contador = 0; //El contador que guardará donde va cada usuario
                        if(datosJSON[0] != null && datosJSON[0].Trim() != ""){
                            foreach(string datos in datosJSON){ //Recorremos el array
                                //Introducimos los datos de esa linea de json en el array de usuarios
                                datosUsuarios[contador] = JsonUtility.FromJson<scClaseUsuario>(datos); 
                                contador++; //y contamos
                            }
                            scAccesoDatos.GuardarDatosUsuario(datosUsuarios); //Pasamos los datos para guardar
                            txtMensaje.color = Color.green; //Modificamos su color
                            txtMensaje.text = "DATOS CARGADOS CORRECTAMENTE"; //Indicamos que se han cargado correctamente
                        }
                    }
                    else{
                        txtMensaje.text = "EL ARCHIVO NO EXISTE"; //El archivno no existe 
                    }
                }
                else if(Path.GetExtension(path[0]).ToLower() != ".json"){
                    
                    txtMensaje.text = "LA EXTENSIÓN DEL ARCHIVO NO ES .JSON"; //Indicamos que la extensión no es JSON
                }
            }
            else{
                txtMensaje.text = "SE HA CANCELADO LA IMPORTACIÓN";
            }    
        }catch(Exception e){ //Si salta una exception
            txtMensaje.text = "HA OCURRIDO UN ERROR MIENTRAS SE IMPORTABA";
             Debug.LogError("La exception que ha ocurrido arroja el siguiente mensaje: "+e.Message);
        }
        
    }
}
