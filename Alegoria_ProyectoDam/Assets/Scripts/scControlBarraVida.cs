using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scControlBarraVida : MonoBehaviour
{
    public GameObject jugador;  //Asignar el personaje al que seguirá
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeguirJugador();

    }

    private void SeguirJugador(){ //Método para que la barra de vida se encuentre siempre encima del personaje
        Vector2 posicionActual = new Vector2(this.transform.position.x, this.transform.position.y); //Posición actual de la barra
        Vector2 posicionObjetivo = new Vector2(jugador.transform.position.x, jugador.transform.position.y+1f); //Mueve con el usuario pero 0,75f por encima para ser visible
        Vector2 posicionFinal = Vector2.Lerp(posicionActual, posicionObjetivo, 100f); //Posiciñon a donde llegar
        this.transform.position = new Vector3(posicionFinal.x, posicionFinal.y, this.transform.position.z); //Se mueve a la posición final
    }
}
