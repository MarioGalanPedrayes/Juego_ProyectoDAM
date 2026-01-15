using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scMostrarUsuario : MonoBehaviour
{
    public Text textoUsuario; //Texto del canvas que mostrará el nombre de usuario
    public scDatosUsuario scDatosUsuario;
    void Start()
    {
        textoUsuario.text += scDatosUsuario.GetNombre();
    }

}
