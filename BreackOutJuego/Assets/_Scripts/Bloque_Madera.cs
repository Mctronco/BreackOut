using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Madera : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        //resistencia = 3;
        CambioDeResistencia(3, 6, 9);
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }


}
