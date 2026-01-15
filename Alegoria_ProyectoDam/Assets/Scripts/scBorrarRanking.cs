using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class scBorrarRanking : MonoBehaviour
{
    public Text textoInformacion;
    private string ruta = "";
    public void borrarDatosRanking(){
        ruta = scAccesoDatos.getRutaDatosGuardados();
        if(File.Exists(ruta)){ //Si existe la ruta porque hay datos
            File.Delete(ruta); //Borra esos datos
            textoInformacion.color = Color.green; //Ponemos las letras en verde para que el usuario no piense que es un error
            textoInformacion.text = "SE HAN BORRADO LOS DATOS"; //Se indica que se han borrado los datos
        } //sino
        else{ //retorna null
            textoInformacion.color = Color.red; //Ponemos las letras en rojo
            textoInformacion.text = "NO SE HAN ENCONTRADO DATOS QUE BORRAR"; //Se indica que se han borrado los datos;
        }
    }
}
