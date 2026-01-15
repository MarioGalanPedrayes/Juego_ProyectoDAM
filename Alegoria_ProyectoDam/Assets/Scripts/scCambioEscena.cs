    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement; //Clase importada manualmente
    using UnityEngine.UI;
    public class scCambioEscena : MonoBehaviour
    {
        public InputField ifNombre;
        public scDatosUsuario scDatosUsuario;
        public Slider sliNivelElegido;
        public Text txtError;
        public Text btnTxtNivelDirecto;

        
        //Este método pedirá que introduzcamos un texto , debemos introducir la escena donde cargamos nuestsro juego
        public void CargarNivel(string levelname)
        {
            SceneManager.LoadScene(levelname);
        }
        public void CargarEscenaConDatos(string levelname){
            //Damos el valor del nombre a los datos del jugador
            if((ifNombre.text).Trim() != "" && ifNombre.text != null){ //¿El nombre (quitando espacios) es distinto de vacio o nulo?
                scDatosUsuario.SetNombre(ifNombre.text); //Dale el valor del nombre introducido a los datos del usuario
                scDatosUsuario.ReiniciarPuntuacion(); //Reiniciamos la puntuación para el nuevo juego
                SceneManager.LoadScene(levelname); //Y carga la escejna
            }
            else{ //Si el nombre esta vacio o vale null
                txtError.text = "NO SE PUEDE INTRODUCIR UN NOMBRE VACIO";
            }
        }

        public void CargarNivelEspecifico(){
            //Damos el valor del nombre a los datos del jugador
            if((ifNombre.text).Trim() != "" && ifNombre.text != null){ //¿El nombre (quitando espacios) es distinto de vacio o nulo?
                scDatosUsuario.SetNombre(ifNombre.text); //Dale el valor del nombre introducido a los datos del usuario
                scDatosUsuario.ReiniciarPuntuacion(); //Reiniciamos la puntuación para el nuevo juego
                SceneManager.LoadScene("Nivel"+(sliNivelElegido.value).ToString()); //Y carga la escena del nivel elegido en el slider
            }
            else{ //Si el nombre esta vacio o vale null
                txtError.text = "NO SE PUEDE INTRODUCIR UN NOMBRE VACIO";
            }
        }

        public void ModificarTextoBoton() { //Método llamado al modificar el slider
            btnTxtNivelDirecto.text = "Ir al nivel " + sliNivelElegido.value; //Vamos modificando el nivel elegido en el slider    
        }
        
        public void Salir()
        {
            Application.Quit();
        }
    }
