using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float startDelay = 1f;
    public float interval = 2f;

    private bool activo = false;

    public void Activar()
    {
        if (activo) return;
        activo = true;
        InvokeRepeating(nameof(Spawn), startDelay, interval);
    }

    public void Desactivar()
    {
        activo = false;
        CancelInvoke(nameof(Spawn));
    }

    void Spawn()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}