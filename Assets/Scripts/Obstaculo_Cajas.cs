using UnityEngine;

public class Obstaculo_Cajas : MonoBehaviour
{
    public float altura = 0.5f;
    public float velocidad = 2f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float movimientoY = Mathf.Abs(Mathf.Sin(Time.time * velocidad)) * altura;

        transform.position = new Vector3(
            posicionInicial.x,
            posicionInicial.y + movimientoY,
            posicionInicial.z
        );
    }
}