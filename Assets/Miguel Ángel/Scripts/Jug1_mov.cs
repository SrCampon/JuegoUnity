using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

// JUGADOR ROJO
public class PlayerController : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento
    private Rigidbody rb;

    public GameObject projectilePrefab; // El prefab del proyectil
    public float projectileSpeed = 20f; // Velocidad del proyectil
    private Vector3 lastMovementDirection = Vector3.forward; // Dirección predeterminada

    // Variables para el audio
    public AudioClip shootSound; // Clip de audio para el disparo
    private AudioSource audioSource; // Referencia al AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evitar rotaciones no deseadas

        // Configurar el AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement.magnitude > 0.1f)
        {
            lastMovementDirection = movement.normalized;
        }

        rb.linearVelocity = movement * speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear el proyectil
        Vector3 spawnPosition = transform.position + lastMovementDirection * 0.5f;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        Rigidbody rbProjectile = projectile.GetComponent<Rigidbody>();
        rbProjectile.linearVelocity = lastMovementDirection * projectileSpeed;

        Destroy(projectile, 3f);

        // Reproducir el sonido del disparo
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el jugador ha chocado con un proyectil
        if (collision.gameObject.CompareTag("Projectile"))
        {
            SceneManager.LoadScene("GanaAzul");
        }

        if (collision.gameObject.CompareTag("Meta"))
        {
            SceneManager.LoadScene("GanaRojo");
        }
    }
}
