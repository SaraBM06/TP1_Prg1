using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplicador = 2f;
    public float duracion = 5f;
    public float cooldown = 10f;

    private bool disponible = true;
    private Renderer rend;
    private Color colorOriginal;

    void Start()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (disponible && other.CompareTag("Player"))
        {
            PlayerMovement jugador = other.GetComponent<PlayerMovement>();
            if (jugador != null)
            {
                StartCoroutine(Activar(jugador));
            }
        }
    }

    IEnumerator Activar(PlayerMovement jugador)
    {
        disponible = false;

        jugador.speed = jugador.velocidadOriginal * multiplicador;
        rend.material.color = Color.gray;
        Debug.Log("Power-Up activado");

        yield return new WaitForSeconds(duracion);

        jugador.speed = jugador.velocidadOriginal;
        Debug.Log("Power-Up terminado, en recarga");

        yield return new WaitForSeconds(cooldown);

        disponible = true;
        rend.material.color = colorOriginal;
        Debug.Log("Power-Up disponible otra vez");
    }
}