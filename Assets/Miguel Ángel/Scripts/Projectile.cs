using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Destruye el proyectil cuando colisione con cualquier objeto
        Destroy(gameObject);

    }
}
