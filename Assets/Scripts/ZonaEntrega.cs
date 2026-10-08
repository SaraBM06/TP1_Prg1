using UnityEngine;

public class ZonaEntrega : MonoBehaviour
{
    public Color colorVictoria = Color.green;

    private Renderer rend;
    private bool victoria = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (victoria) return;

        // Solo cuenta el objeto solicitado, no el jugador
        if (other.CompareTag("Recogible"))
        {
            // Debe estar suelto (no llevado por el jugador)
            if (other.transform.parent == null)
            {
                Ganar();
            }
        }
    }

    void Ganar()
    {
        victoria = true;
        Debug.Log("¡Victoria! Objeto entregado");

        if (rend != null)
        {
            rend.material.color = colorVictoria;
        }
    }

    void OnGUI()
    {
        if (victoria)
        {
            GUIStyle estilo = new GUIStyle(GUI.skin.label);
            estilo.fontSize = 48;
            estilo.alignment = TextAnchor.MiddleCenter;
            estilo.normal.textColor = Color.yellow;

            GUI.Label(new Rect(0, 0, Screen.width, Screen.height),
                      "¡VICTORIA!", estilo);
        }
    }
}
