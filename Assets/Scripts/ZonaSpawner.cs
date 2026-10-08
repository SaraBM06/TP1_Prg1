using UnityEngine;

public class ZonaSpawner : MonoBehaviour
{
    public Spawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró: " + other.name);

        if (other.CompareTag("Player"))
        {
            spawner.Activar();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.Desactivar();
        }
    }
}
