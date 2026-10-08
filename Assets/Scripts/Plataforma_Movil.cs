using UnityEngine;

public class Plataforma_Movil : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float distance = 4f;
    public float speed = 2f;
    public float waitTime = 2f;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 target;
    private bool goingToB = true;

    void Start()
    {
        posA = transform.position - direction.normalized * (distance / 2f);
        posB = transform.position + direction.normalized * (distance / 2f);
        transform.position = posA;
        target = posB;

        Invoke(nameof(ChangeTarget), waitTime);
    }

    void Update()
    {
         transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }

    void ChangeTarget()
    {
        goingToB = !goingToB;
        target = goingToB ? posB : posA;

        Invoke(nameof(ChangeTarget), waitTime);
    }
}