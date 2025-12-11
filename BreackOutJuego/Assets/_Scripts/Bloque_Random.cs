using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Random : Bloque

{
    // Start is called before the first frame update
    void Start()
    {
        int numeroRandom = 0;
        numeroRandom = Random.Range(0, 7);
        resistencia = numeroRandom;
        Debug.Log(resistencia);
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }


}
