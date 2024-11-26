using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // El prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil

    private Vector3 lastMovementDirection = Vector3.forward; // Dirección predeterminada

    void Update()
    {
        // Detectar el movimiento del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Si el jugador se está moviendo, actualiza la última dirección de movimiento
        if (movement.magnitude > 0.1f)
        {
            lastMovementDirection = movement.normalized; // Normalizamos para obtener un vector unitario
        }

        // Detectar si se pulsa la tecla Espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Calcular una posición ligeramente separada en la dirección del disparo
        Vector3 spawnPosition = transform.position + lastMovementDirection * 0.5f; // Ajusta "0.5f" según la distancia deseada
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);


        // Aplicar velocidad al proyectil en la última dirección de movimiento
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity = lastMovementDirection * projectileSpeed;

        // Destruir el proyectil después de 3 segundos (para evitar acumulación)
        Destroy(projectile, 3f);
    }
}
