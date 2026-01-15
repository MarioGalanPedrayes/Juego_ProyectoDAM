using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class scExportarDatosJSON : MonoBehaviour
{
    private scClaseUsuario[] datosUsuario; //Los usuarios a exportar
    public Text txtMensaje; //El texto que indicará que todo ha ido bien
    public void ExportarDatosJSON(){
        txtMensaje.color = Color.red; //Por defecto el color de los mensajes será rojo
        try{//Intenta
            //Pido al usuario que seleccione la ruta para guardar el JSON
            string rutaJSON =StandaloneFileBrowser.SaveFilePanel("Indique donde exportar los datos", Application.persistentDataPath, "datosUsuario" ,"json");
                if(rutaJSON != null && rutaJSON.Trim() != ""){ //Si ha seleccionado una ruta que no sean espacios
                    //Y cargo los datos del archivo de guardado
                    if(scAccesoDatos.CargarDatosUsuario() != null){
                        datosUsuario = scAccesoDatos.CargarDatosUsuario();
                        string datosJSON = ""; //Creamos la cadena JSON
                        foreach(scClaseUsuario  usuario in datosUsuario){
                            datosJSON += JsonUtility.ToJson(usuario); //Y recorremos los usuarios añadiendolos al JSON
                            datosJSON += "\n";
                        }
                        File.WriteAllText(rutaJSON, datosJSON); //Escribo el JSON
                        txtMensaje.color = Color.green; //cambio el color del texto a verde indicando que no es un error
                        txtMensaje.text = "DATOS EXPORTADOS CORRECTAMENTE"; //He indico que se exporto correctamente
                    }
                    else{
                        txtMensaje.text = "NO HAY DATOS QUE EXPORTAR";
                    }
            }
            else{ //Si ha cancelado
                txtMensaje.text = "SE HA CANCELADO LA EXPORTACIÓN";
            }
        }catch(Exception e){ //Si salta una exception
            txtMensaje.text = "HA OCURRIDO UN ERROR MIENTRAS SE EXPORTABA";
            Debug.LogError("La exception que ha ocurrido arroja el siguiente mensaje: "+e.Message);
        }
    }
}
