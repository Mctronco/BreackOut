using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Opciones;

public class DificultadBloques : MonoBehaviour
{

    public Opciones opciones; 
    private int resistencia;

    // Start is called before the first frame update
    void Start()
    {
        if (opciones != null)
        {
            if (opciones.NivelDificultad == Opciones.dificultad.facil)
                resistencia = 1;
            else if (opciones.NivelDificultad == Opciones.dificultad.normal)
                resistencia = 2;
            else 
                resistencia = 3;
        }
        else
        {
            resistencia = 1; 
        }
    }

   
}
