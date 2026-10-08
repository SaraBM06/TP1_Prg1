using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 6f;      
    public float alturaLimite = -10f; 
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        
        if (transform.position.y < alturaLimite)
        {
            Destroy(gameObject);
        }
    }
}