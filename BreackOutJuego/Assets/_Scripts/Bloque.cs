using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static Opciones;

public class Bloque : MonoBehaviour
{
    public int resistencia = 1;
    public UnityEvent AumentarPuntuaje;
    public Opciones opciones_SO;
    public dificultad NivelDificultad;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }

    public void CambioDeResistencia(int facil, int medio, int dificil)
    {
        if (opciones_SO != null)
        {
            if (opciones_SO.NivelDificultad == Opciones.dificultad.facil)
                resistencia = facil;
            else if (opciones_SO.NivelDificultad == Opciones.dificultad.normal)
                resistencia = medio;
            else if (opciones_SO.NivelDificultad == Opciones.dificultad.dificil)
                resistencia = dificil;
        }
        else
        {
            resistencia = 1;
        }
    }
        

    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        resistencia--;
    }

     // Start is called before the first frame update
      void Start()
      {
        CambioDeResistencia(1, 2, 3);
    }

      // Update is called once per frame
      void Update()
      {
          if (resistencia <= 0)
          {
            AumentarPuntuaje.Invoke();  
            Destroy(this.gameObject);
          }
      }
    

    public virtual void RebotarBola()
    {

    }

}
