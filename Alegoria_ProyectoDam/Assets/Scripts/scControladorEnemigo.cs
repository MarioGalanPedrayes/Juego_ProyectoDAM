using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class scControladorEnemigo : MonoBehaviour
{

    public GameObject textoFlotante; //Texto que se instanciará
    public AudioSource sonidoError; //Sonido que sonará al colisionar
    private string[]  textos = {"¿Merece la pena?", //Textos que aparecerán al tocar al personaje
        "No puedes con esto",
        "¿Para qué tanto esfuerzo?",
        "No vales para nada",
        "Seguro que todos fingen que te aguantan",
        "¿Ha merecido la pena todo?",
        "No puedes aguantar más",
        "Ríndete",
        "Todos te odian",
        "Nadie te quiere"};

    //Variables para el movimiento 
    public GameObject jugador;  //Asignar el personaje al que seguirán
    public float velocidadEnemigo = 0.003f; //Establecer velocidad de persecución
    public float maxDist = 8; //Establecer distancia máxima a la que lo seguirá
    public float minDist = 0.1f;//Establecer distancia mínima a la que lo seguirá

    void FixedUpdate()
    {
        MovimientoEnemigo();
    }

    private void OnCollisionEnter2D(Collision2D colision){ //Cuando colisiona
          
        SacarTexto(); //Sale el popup del texto
        SonidoColision(); //Y suena la colisión
    } 

    private void MovimientoEnemigo(){
        //He usado el script de la camara para darle movimiento al enemigo
        Vector2 posicionActual = new Vector2(this.transform.position.x, this.transform.position.y); //Posición actual del enemigo
        Vector2 posicionObjetivo = new Vector2(jugador.transform.position.x, jugador.transform.position.y); //Posición a donde tiene que llegar

        var distancia = Vector3.Distance(posicionActual,posicionObjetivo); //La distancia entre ambas posiciones
        if(  distancia >= minDist && distancia <= maxDist  ){ //Si se encuentra entre la distancia mínima y máxima a donde queremos que llegue
       
            Vector2 posicionFinal = Vector2.Lerp(posicionActual, posicionObjetivo, velocidadEnemigo); //Muevete a esta dirección
            this.transform.position = new Vector3(posicionFinal.x, posicionFinal.y, this.transform.position.z); //Se mueve el enemigo
        }
    }

    private void SacarTexto(){ //Método que sacará el texto en pantalla
        //Indicamos que la posición en la que salga el texto sea debajo de los enemigos y más centrado
        Vector2 posicionTextoPopUp = new Vector2(this.transform.position.x - 1f, this.transform.position.y -1f);
        
        Quaternion rotacionNula = new Quaternion (0, 0, 0, 1);
        //Instanciamos el texto en la posición actual y lo guardamos en una variable
        var texto = Instantiate(textoFlotante,posicionTextoPopUp, rotacionNula , transform);
        int valorAleatorio = UnityEngine.Random.Range(0, textos.Length);
        //Esa variable se modificaraá para darle el valor de un texto aleatorio de la cadena de arrays
        texto.GetComponent<TextMesh>().text = textos[valorAleatorio];
        texto.GetComponent<TextMesh>().color = Color.black; //Cambiamos el color a negro
        texto.GetComponent<TextMesh>().fontSize = 16; //Le indicamos el tamaño de la fuente

    }

    private void SonidoColision(){
        var sonido = Instantiate(sonidoError, transform.position, transform.rotation); //Creo una isntancia del sonido
        sonido.Play(); //Suena al colisionar 
    }
}
