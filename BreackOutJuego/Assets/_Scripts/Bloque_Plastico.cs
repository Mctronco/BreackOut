using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Plastico : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        //resistencia = 2;
        CambioDeResistencia(2, 4, 6);
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }


}
