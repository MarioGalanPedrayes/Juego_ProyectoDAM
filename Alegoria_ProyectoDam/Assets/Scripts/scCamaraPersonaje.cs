using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCamaraPersonaje : MonoBehaviour
{
    //Para saber qué seguirá la cámara
    public GameObject player = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posicionActual = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 posicionObjetivo = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 posicionFinal = Vector2.Lerp(posicionActual, posicionObjetivo, 0.05f); //El float es velocidad de la cámara
        this.transform.position = new Vector3(posicionFinal.x, posicionFinal.y, this.transform.position.z);

    }
}
