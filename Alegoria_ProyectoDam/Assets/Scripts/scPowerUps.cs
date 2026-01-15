    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class scPowerUps : MonoBehaviour
    {
        public scControlPersonaje personaje; //Script del personaje
        // Start is called before the first frame update

        private void OnCollisionEnter2D(Collision2D colision){ //Si colisiona
            if ( colision.gameObject.tag == "Personaje"){ //Si colisiona el personaje
                if (this.gameObject.tag.Contains("pwInvencible")){ //Si el objeto contiene la etiqueta pwInvencible
                    personaje.setInvencible(true); //Enviamos el true al valor del booleano invencible del scControlPersonaje
                }
                else if (this.gameObject.tag.Contains("pwAgresivo")){ //Si el objeto contiene la etiqueta pwAgresivo
                    personaje.setAgresivo(true); //Enviamos el true al valor del booleano agresivo del scControlPersonaje
                }
                else if(this.gameObject.tag.Contains("pwMultiplicar")){ //Si el objeto contiene la etiqueta pwMultiplicar
                    personaje.setMultiplicar(true); //Enviamos el true al valor del booleano multiplicar del scControlPersonaje
                }
            }
        }


    }
