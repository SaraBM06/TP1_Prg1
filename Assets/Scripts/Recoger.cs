using UnityEngine;

public class Recoger : MonoBehaviour
{
    public Transform puntoTransporte;
    public float distanciaRecoger = 2f;
    public KeyCode teclaRecoger = KeyCode.E;
    public KeyCode teclaSoltar = KeyCode.Q;

    private Transform objetoLlevado;
    private Rigidbody rbObjeto;

    void Update()
    {
        if (Input.GetKeyDown(teclaRecoger) && objetoLlevado == null)
        {
            IntentarRecoger();
        }
        else if (Input.GetKeyDown(teclaSoltar) && objetoLlevado != null)
        {
            Soltar();
        }
    }

    void IntentarRecoger()
    {
        Collider[] cercanos = Physics.OverlapSphere(transform.position, distanciaRecoger);

        foreach (Collider c in cercanos)
        {
            if (c.CompareTag("Recogible"))
            {
                objetoLlevado = c.transform;
                rbObjeto = c.GetComponent<Rigidbody>();

                if (rbObjeto != null)
                {
                    rbObjeto.isKinematic = true;
                }
                c.enabled = false;

                objetoLlevado.SetParent(puntoTransporte);
                objetoLlevado.localPosition = Vector3.zero;
                objetoLlevado.localRotation = Quaternion.identity;
                break;
            }
        }
    }

    void Soltar()
    {
        objetoLlevado.SetParent(null);

        objetoLlevado.GetComponent<Collider>().enabled = true;
        if (rbObjeto != null)
        {
            rbObjeto.isKinematic = false;
        }

        objetoLlevado = null;
        rbObjeto = null;
    }
}