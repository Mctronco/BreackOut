using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{

    public bool isGameStarted = false;
    [SerializeField] public float velocidadBola = 10.0f;
    Vector3 ultimaPosicion = Vector3.zero;
    Vector3 direccion = Vector3.zero;
    Rigidbody rigidbody;
    private ControlBordes control;
    public UnityEvent BolaDestruida;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);
        rigidbody = this.gameObject.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();
            Destroy(this.gameObject);
        }
        if (control.salioArriba)
        {
            direccion=transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde superiror");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde izquierdo");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if (!isGameStarted)
            {
                isGameStarted = true;
                this.transform.SetParent(null);

                // Velocidad inicial hacia arriba
                Vector3 v = velocidadBola * Vector3.up;

                // Evitar que sea exactamente vertical (Y) o exactamente horizontal (X)
                float angulo = Random.Range(-0.5f, 0.5f); // Ajusta este valor según lo quieras
                v.x = velocidadBola * angulo;

                GetComponent<Rigidbody>().velocity = v;
            }
        }
        
    }
   

    private void FixedUpdate()
    {
        ultimaPosicion= transform.position;
    }

    public void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }
}
