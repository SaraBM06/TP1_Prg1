using UnityEngine;

public class Plataforma_Movil : MonoBehaviour
{
    public Vector3 desplazamiento = new Vector3(0f, 0f, 4f); // cuánto se mueve en X, Y, Z
    public float speed = 1.5f;
    public float waitTime = 2.5f;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 target;
    private bool goingToB = true;

    void Start()
    {
        posA = transform.position;              // punto A = donde la colocaste
        posB = posA + desplazamiento;           // punto B = A + desplazamiento
        target = posB;

        Invoke(nameof(ChangeTarget), waitTime);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void ChangeTarget()
    {
        goingToB = !goingToB;
        target = goingToB ? posB : posA;

        Invoke(nameof(ChangeTarget), waitTime);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 inicio = Application.isPlaying ? posA : transform.position;
        Vector3 fin = Application.isPlaying ? posB : transform.position + desplazamiento;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(inicio, fin);
        Gizmos.DrawWireSphere(inicio, 0.3f);
        Gizmos.DrawWireSphere(fin, 0.3f);
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}