using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scTextoFlotante : MonoBehaviour
{

    public float temporizador = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, temporizador); //Destruye el objeto tras 4f
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}   
