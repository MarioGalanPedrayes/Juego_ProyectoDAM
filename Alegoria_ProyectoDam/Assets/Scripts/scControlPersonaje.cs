using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement; //Clase importada manualmente
public class scControlPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public float movX = 5f; //Movimiento en eje X
    public GameObject camaraJuego;
    public float movY = 5f; //Movimiento en eje X
    public string levelname; //Escena a la que cargar
    public  GameObject barraVida; //La barra de vida
    private float tamannoBarraVidaInicial; //Guarda el tamaño de la barra de vida inical
    private float tamannoBarraVidaActual; //Guarda la vida actual
    private float anchoBarraVida; //El ancho de la barra de vida por si surgen modificaciones
    private float temporizadorCambioColor = 0f; //Temporizador para modificar el color
    public float golpesRestantes = 3f; //Golpes que recibirá el personaje antes de morir
    public float maximoTiempoInvencible = 25f; //Tiempo por el que será invencible el personaje tras coger el powerup
    private float temporizadorInvencible = 0f; //Temporizador invencible
    private Boolean pwInvencible = false; //Invencibilidad del personaje
    public float maximoTiempoAgresivo = 2f; //Tiempo por el que será agresivo el personaje tras coger el powerup
    private float temporizadorAgresivo = 0f; //Temporizador agresivo
    private Boolean pwAgresivo = false;//Agresividad del personaje
    public float maximoTiempoMultiplicar = 40f; //Tiempo por el que multiplicará la puntuación el personaje tras coger el powerup
    private float temporizadorMultiplicar = 0f; //Temporizador multiplicar
    public float valorAMultiplicar = 1; //Valor por el que se multiplicará la puntuación recogida (se modificará en caso de tener pwMultiplicar a true)
    private Boolean pwMultiplicar = false; //Multiplicación de puntos activada para el personaje
    public scDatosUsuario scDatosUsuario; //Datos persistentes del usuario
    public scPuntuacion puntuacion; //GameObject con el script scPuntuacion que guardará y modificará la puntuación
    //VALORES PARA LA PUNTUACIÓN
    public float golpeDeEnemigo = 2; //Puntos que restará ser golpeado por un enemigo
    public float eliminarEnemigo = 5; //Puntos que sumará eliminar a un enemigo
    public float cogerPowerUp = 2; //Puntos que sumará coger un powerup

    //VALORES PARA ANIMACIONES
    private Animator animaciones; //Objeto animator para darle valores a las variables encargadas de estas animaciones
    
    void Start()
    {
        anchoBarraVida = barraVida.transform.localScale.y; //Cogemos el valor del alto de la barra
        tamannoBarraVidaInicial = barraVida.transform.localScale.x; //Cogemos el valor del ancho de la barra
        tamannoBarraVidaActual = tamannoBarraVidaInicial; //E indicamos que el tamaño actual de la barra es el inicial

        animaciones = this.GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        
        comprobarPowerUp(); //Comprueba los powersUp
        resetearAnimacion(); //Método que modifica los valores de la animación en funciones de las teclas pulsadas
       // cambioColor(); //Cambia el color del sprite a blanco
    }

    private void FixedUpdate() {
        movimientoLineal(); //Movimiento del personaje
    }
  
    private void cambioColor(float maximoTemporizadorCambioColor){
        if( this.GetComponent<SpriteRenderer>().color != Color.black){ //Si el color del personaje es rojo
            temporizadorCambioColor += Time.deltaTime; //Sigue sumando
            if(temporizadorCambioColor >= maximoTemporizadorCambioColor){ //Si ya ha pasado el tiempo indicado
                
                this.GetComponent<SpriteRenderer>().color = Color.white; //Vuelve a tener color rojo
                temporizadorCambioColor = 0f;
            }
        }
    }

    

    private void movimientoLineal(){ //Movimiento del personaje

        if(Input.GetKey(KeyCode.W)){
            this.transform.position += new Vector3(0, movY, 0);
        }         
        else if(Input.GetKey(KeyCode.S)){
            this.transform.position += new Vector3(0, -movY, 0);
        }

        if(Input.GetKey(KeyCode.D)){
            this.transform.position += new Vector3(movX, 0, 0);
            
        }
        else if(Input.GetKey(KeyCode.A)){
            this.transform.position += new Vector3(-movX, 0, 0);
                      

        }
       
    }

    private void resetearAnimacion(){
         if(Input.anyKey){ //Si esta pulsando alguna tecla
            
            if(Input.GetKey(KeyCode.W)){
                //Damos los valores en la animación en caso de que pulsen las teclas
                animaciones.SetFloat("Vertical", 1);
                animaciones.SetBool("Movimiento", true);
            }
            
            else if(Input.GetKey(KeyCode.S)){
                animaciones.SetFloat("Vertical", -1);
                animaciones.SetBool("Movimiento", true);        

            }
            if(Input.GetKey(KeyCode.D)){
                animaciones.SetFloat("Horizontal", 1);
                animaciones.SetBool("Movimiento", true);          

            }
            else if(Input.GetKey(KeyCode.A)){
                animaciones.SetFloat("Horizontal", -1);
                animaciones.SetBool("Movimiento", true);       

            }
            if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){ //Si dejamos de pulsar estas teclas
                animaciones.SetFloat("Vertical", 0); //Ponemos el correspondiente valor a 0
            }
            if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
                animaciones.SetFloat("Horizontal", 0);
            }
        }
        else{ //Resetamos el movimiento para poner la animación por defecto (Idle) y resetear el valor del movimiento, vertical y horizontal
            animaciones.SetBool("Movimiento", false);
            animaciones.SetFloat("Horizontal", 0);
            animaciones.SetFloat("Vertical", 0); 
        }
    }

    private void comprobarPowerUp(){
        tiempoInvencibilidad(); //Método que gestiona el tiempo de la invencibilidad del personaje
        tiempoAgresividad(); //Método que gestiona el tiempo de la agresividad del personaje
        tiempoMultiplicar(); //Método que gestiona el tiempo de multiplicación del personaje
    }
    private void tiempoInvencibilidad(){//Método que gestiona la invencibilidad del personaje
        temporizadorInvencible += Time.deltaTime; //Temporizador invencible
        if(pwInvencible == true) { //Si el invencible vale true
            this.GetComponent<SpriteRenderer>().color = Color.yellow; //Cambia el color a amarillo
        }
        if(temporizadorInvencible >= maximoTiempoInvencible ){ //Si lleva maximoTiempoInvencible
                cambioColor(maximoTiempoInvencible);
                pwInvencible = false; //Deja de ser invencible
               
        }
    }
    private void tiempoAgresividad(){
        temporizadorAgresivo += Time.deltaTime; //Temporizador agresivo
        if(pwAgresivo == true) { //Si el agresivo vale true
            this.GetComponent<SpriteRenderer>().color = Color.magenta; //Cambia el color a magenta
        }
        if(temporizadorAgresivo >= maximoTiempoAgresivo ){ //Si lleva maximoTiempoAgresivo 
                cambioColor(maximoTiempoAgresivo);
                pwAgresivo = false; //Deja de ser agresivo
               
        }
    }

    private void tiempoMultiplicar(){
        temporizadorMultiplicar += Time.deltaTime; //Temporizador agresivo
        if(pwMultiplicar == true) { //Si el agresivo vale true
            this.GetComponent<SpriteRenderer>().color = Color.blue; //Cambia el color a azul
        }
        if(temporizadorMultiplicar >= maximoTiempoMultiplicar ){ //Si lleva maximoTiempoMultiplicar 
                cambioColor(maximoTiempoMultiplicar);
                pwMultiplicar = false; //Deja de multiplicar
               
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {  //Método para la colisión
        if(pwMultiplicar == true){ //Si ha cogido el powerUp para multiplicar la puntuación
            valorAMultiplicar = 2; //Multiplica la puntuación x 2
        }
        else{ //Si no
            valorAMultiplicar = 1; //Multiplicara x 1 (se queda como está)
        }
        if(collision.gameObject.tag.Contains("Tutorial")){ //Si la colisión se produce con un elemento en el tutorial no se enviará puntuación
            if (collision.gameObject.tag.Contains("Meta")) { //Si la etiqueta es meta
                SceneManager.LoadScene(levelname); //Carga la escena indicada en unity
            }
            else if(collision.gameObject.tag.Contains("Enemigo") & pwAgresivo){ //Si colisionamos con un enemigo mientras esta agresivo
                Destroy(collision.gameObject); //Destruye al enemigo
            }
            else if(collision.gameObject.tag.Contains("Enemigo")){ //Si la etiqueta es enemigo
                if( pwInvencible != true ) { //Si no es invencible
                    this.GetComponent<SpriteRenderer>().color = Color.red; //Pon el color del personaje rojo
                    VibracionCamara();
                    DisminuirBarraVida();
                }
            }
            else if(collision.gameObject.tag.Contains("pw")){ //Si el objeto con el que colisiona es un powerUp
                Destroy(collision.gameObject); //Destruye el objeto
            }
        }    
        else if (collision.gameObject.tag == "Meta") { //Si la etiqueta es meta
            scDatosUsuario.SetPuntuacion(puntuacion.getPuntuacionFinalNivel()); //Le pasamos al gameObject con los datos del usuario la puntuación conseguida restando el tiempo

            SceneManager.LoadScene(levelname); //Carga la escena indicada en unity
        }
        else if(collision.gameObject.tag == "Enemigo" & pwAgresivo){ //Si colisionamos con un enemigo mientras esta agresivo
            Destroy(collision.gameObject); //Destruye al enemigo
            puntuacion.setPuntuacion(eliminarEnemigo * valorAMultiplicar); //puntuación por enemigo eliminado multiplicado por el valor de multiplicar (1 si no ha cogido el pwMultiplicar)
        }
        else if(collision.gameObject.tag == "Enemigo"){ //Si la etiqueta es enemigo
            if( pwInvencible != true ) { //Si no es invencible
                this.GetComponent<SpriteRenderer>().color = Color.red; //Pon el color del personaje rojo
                puntuacion.setPuntuacion(-golpeDeEnemigo); //puntuación por golpe de enemigo
                VibracionCamara();
                DisminuirBarraVida();
            }
        }
        else if(collision.gameObject.tag.Contains("pw")){ //Si el objeto con el que colisiona es un powerUp
            puntuacion.setPuntuacion(cogerPowerUp * valorAMultiplicar); //puntuación por powerup conseguido  multiplicado por el valor de multiplicar (1 si no ha cogido el pwMultiplicar)
            Destroy(collision.gameObject); //Destruye el objeto
        }
    }

    private void VibracionCamara(){
    //Permite una ligera vibración en la cámara al colisionar, modificando de forma rápida la posición de esta y recolocandose gracias al script de scCamaraPersonaje
        Vector3 posicionInicial =  new Vector3(camaraJuego.transform.position.x, camaraJuego.transform.position.y, camaraJuego.transform.position.z);
        Vector2 posicionFinal = new Vector2(camaraJuego.transform.position.x-0.5f, 
            camaraJuego.transform.position.y +0.5f);

        Vector2 movimientoVibracion = Vector2.Lerp(posicionInicial, posicionFinal, 0.5f);
        
        camaraJuego.transform.position = new Vector3(movimientoVibracion.x, movimientoVibracion.y, camaraJuego.transform.position.z);

    }

    private void DisminuirBarraVida(){
        tamannoBarraVidaActual -= tamannoBarraVidaInicial/golpesRestantes; //Voy restando el tamaño de la barra
        barraVida.transform.localScale = new Vector2(tamannoBarraVidaActual,anchoBarraVida); //Y actualizo 
        if(tamannoBarraVidaActual < 0.01){ //Si la vida es menor de 0,01 (no puedo usar 0 por numeros impares) 
            SceneManager.LoadScene("GameOver");  //salta a la pantalla de gameOVer
        }
    }

    public void setInvencible(Boolean setInvencible){
        pwInvencible = setInvencible; //Invencible coge el valor pasado desde el scPowerUps
        temporizadorInvencible = 0f; //Reseteamos el valor del temporizador porque acaba de coger otro powerUp invencible
    }

    public void setAgresivo(Boolean setAgresivo){
        pwAgresivo = setAgresivo; //Agresivo coge el valor pasado desde el scPowerUps
        temporizadorAgresivo = 0f; //Reseteamos el valor del temporizador porque acaba de coger otro powerUp Agresivo
    }

    public void setMultiplicar(Boolean setMultiplicar){
        pwMultiplicar = setMultiplicar;
        temporizadorMultiplicar  = 0f;
    }
}
