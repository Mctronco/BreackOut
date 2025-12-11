using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DificultadBola : MonoBehaviour
{
    public Opciones opciones; 
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float velocidad = opciones.velocidadBola;

        
        if (opciones.NivelDificultad == Opciones.dificultad.facil)
        {
            velocidad = 20f; 
        }
        else if (opciones.NivelDificultad == Opciones.dificultad.normal)
        {
            velocidad = 30f; 
        }
        else // dificil
        {
            velocidad = 40f; 
        }

       
        rb.velocity = rb.velocity.normalized * velocidad;
    }

}
