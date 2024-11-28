using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

//JUGADOR AZUL

public class Player2Controller : MonoBehaviour
{
    // Parámetros de movimiento
    public float speed = 10f; // Velocidad de movimiento
    private Rigidbody rb;

    // Parámetros de disparo
    public GameObject projectilePrefab; // El prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil
    private Vector3 lastMovementDirection = Vector3.forward; // Dirección predeterminada

    void Start()
    {
        // Inicialización del Rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evitar rotaciones no deseadas
    }

    void FixedUpdate()
    {
        // Movimiento del jugador 2
        float moveHorizontal = Input.GetAxis("Horizontal_P2"); // Controles personalizados para jugador 2
        float moveVertical = Input.GetAxis("Vertical_P2");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Actualiza la dirección del último movimiento
        if (movement.magnitude > 0.1f)
        {
            lastMovementDirection = movement.normalized; // Guardar la dirección del movimiento
        }

        // Aplicar movimiento al Rigidbody
        rb.linearVelocity = movement * speed;
    }

    void Update()
    {
        // Detectar si se pulsa la tecla Enter (Return) para disparar
        if (Input.GetKeyDown(KeyCode.Return)) // Enter para disparar
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Calcular posición de aparición del proyectil
        Vector3 spawnPosition = transform.position + lastMovementDirection * 0.5f; // Ajustar según la distancia deseada
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Aplicar velocidad al proyectil
        Rigidbody rbProjectile = projectile.GetComponent<Rigidbody>();
        rbProjectile.linearVelocity = lastMovementDirection * projectileSpeed;

        // Destruir el proyectil después de 3 segundos
        Destroy(projectile, 3f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador ha chocado con un proyectil
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Cambiar a la escena de "GameOver"
            SceneManager.LoadScene("GanaRojo"); // Asegúrate de que la escena esté añadida en Build Settings
        }

        if (collision.gameObject.CompareTag("Meta"))
        {
            SceneManager.LoadScene("GanaAzul");
        }
    }
}
