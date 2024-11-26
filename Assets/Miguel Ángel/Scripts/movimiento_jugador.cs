using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento
    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evitar rotaciones no deseadas
    }

    void FixedUpdate()
    {
        // Leer entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal"); // Flechas izquierda/derecha o A/D
        float moveVertical = Input.GetAxis("Vertical");     // Flechas arriba/abajo o W/S

        // Crear un vector para el movimiento
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Asignar directamente la velocidad al Rigidbody
        rb.linearVelocity = movement * speed;
    }
}
