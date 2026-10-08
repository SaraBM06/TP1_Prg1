using UnityEngine;

public class Sphere_obstaculo : MonoBehaviour
{
    public float velocidad = 1.5f;
    public float limiteIzquierda = -0.10f;
    public float limiteDerecha = 0.10f;

    public bool empezarAlReves = false;

    private float direccion = 1f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;

        if (empezarAlReves)
        {
            direccion = -1f;
        }
    }

    void Update()
    {
        transform.position += Vector3.right * direccion * velocidad * Time.deltaTime;

        if (transform.position.x >= posicionInicial.x + limiteDerecha)
        {
            direccion = -1f;
        }

        if (transform.position.x <= posicionInicial.x + limiteIzquierda)
        {
            direccion = 1f;
        }
    }
}